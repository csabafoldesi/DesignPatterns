using Factories.AbstractFactoryOCP.Abstraction;

namespace Factories.AbstractFactoryOCP.Implementation
{
    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }
}
