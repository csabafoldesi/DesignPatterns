using Factories.AbstractFactoryOCP.Abstraction;

namespace Factories.AbstractFactoryOCP.Implementation
{
    public class FranceShoppingCartPurchaseFactors : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new FranceShippingCostService();
        }
    }
}
