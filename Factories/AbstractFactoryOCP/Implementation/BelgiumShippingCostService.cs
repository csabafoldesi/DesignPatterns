using Factories.AbstractFactoryOCP.Abstraction;

namespace Factories.AbstractFactoryOCP.Implementation
{
    public class BelgiumShippingCostService : IShippingCostService
    {
        public decimal ShippingCost => 80;
    }
}
