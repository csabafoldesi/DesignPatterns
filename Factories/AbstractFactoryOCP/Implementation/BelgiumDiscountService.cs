using Factories.AbstractFactoryOCP.Abstraction;

namespace Factories.AbstractFactoryOCP.Implementation
{
    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }
}
