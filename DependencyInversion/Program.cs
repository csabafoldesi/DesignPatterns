namespace DependencyInversion
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name { get; set; }
    }


    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }


    //low-level
    public class Relationships : IRelationshipBrowser
    {
        private readonly List<(Person, Relationship, Person)> relations = new();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations
                .Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent)
                .Select(r => r.Item3);
        }

        //public List<(Person, Relationship, Person)> Relarions => relations;
    }


    internal class Program
    {
        /*public Program(Relationships relationships)
        {
            var relations = relationships.Relarions;
            foreach(var rel in relations.Where(
                x => x.Item1.Name == "John" && 
                x.Item2 == Relationship.Parent
            ))
            {
                Console.WriteLine($"John has a child called {rel.Item3.Name}");
            }
        }*/

        public Program(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {p.Name}");
            }
        }

        static void Main(string[] args)
        {
            var parent = new Person() { Name = "John" };
            var child1 = new Person() { Name = "Chris" };
            var child2 = new Person() { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Program(relationships);
        }
    }
}