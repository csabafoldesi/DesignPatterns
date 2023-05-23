using Factories.AbstractFactoryOCP.Abstraction;

namespace Factories.AbstractFactoryOCP.Implementation
{
    public class FranceShippingCostService : IShippingCostService
    {
        public decimal ShippingCost => 100;
    }
}
