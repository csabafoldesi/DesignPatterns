using Factories.AbstractFactoryOCP.Implementation;

namespace Factories.AbstractFactoryOCP
{

    public class AbstractFactoryOCPTest
    {
        public static void Run()
        {
            var belgiumShoppingCartPurchaseFactory = new BelgiumShoppingCartPurchaseFactory();
            var shoppingCartForBelgium = new ShoppingCart(belgiumShoppingCartPurchaseFactory);
            shoppingCartForBelgium.CalculateCosts();

            var franceShoppingCartPurchaseFactory = new FranceShoppingCartPurchaseFactors();
            var shoppingCartForFrance = new ShoppingCart(franceShoppingCartPurchaseFactory);
            shoppingCartForFrance.CalculateCosts();
        }
    }
}
