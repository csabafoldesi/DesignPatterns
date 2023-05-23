namespace Factories.AbstractFactoryOCP.Abstraction
{
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();

        IShippingCostService CreateShippingCostService();
    }
}
