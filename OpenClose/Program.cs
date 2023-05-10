namespace OpenClose
{
    public enum Color
    {
        Red, Green, Blue
    }
    
    public enum Size
    {
        Small, Medium, Large, Yuge
    }
    

    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFiler
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        { 
            foreach (Product product in products)
            {
                if(product.Size == size)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (Product product in products)
            {
                if (product.Color == color)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (Product product in products)
            {
                if (product.Size == size && product.Color == color)
                {
                    yield return product;
                }
            }
        }

    }


    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfiedBy(Product item)
        {
            return item.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfiedBy(Product item)
        {
            return item.Size == size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public bool IsSatisfiedBy(T item)
        {
            return first.IsSatisfiedBy(item) && second.IsSatisfiedBy(item);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach(var item in items)
            {
                if(spec.IsSatisfiedBy(item))
                {
                    yield return item;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = {apple, tree, house};

            var productFilter = new ProductFiler();
            Console.WriteLine("Green products (old):");
            foreach(Product product in productFilter.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {product.Name} is green");
            }

            var betterFilter = new BetterFilter();
            Console.WriteLine("Green products (new):");
            foreach(var product in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {product.Name} is green");
            }
            
            Console.WriteLine("Large blue items:");
            foreach(var product in betterFilter.Filter(
                products, 
                new AndSpecification<Product>(
                    new SizeSpecification(Size.Large), 
                    new ColorSpecification(Color.Blue))))
            {
                Console.WriteLine($" - {product.Name} is large and blue");
            }

        }
    }
}