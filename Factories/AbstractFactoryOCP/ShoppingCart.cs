using Factories.AbstractFactoryOCP.Abstraction;

namespace Factories.AbstractFactoryOCP
{
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostService _shippingCostService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factroy)
        {
            _discountService = factroy.CreateDiscountService();
            _shippingCostService = factroy.CreateShippingCostService();

            _orderCosts = 300;
        }

        public void CalculateCosts()
        {
            var totalCosts = _orderCosts
                - (_orderCosts / 100 * _discountService.DiscountPercentage)
                + _shippingCostService.ShippingCost;

            Console.WriteLine($"Total costs = {totalCosts}");
        }
    }
}
