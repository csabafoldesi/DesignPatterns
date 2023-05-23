using Factories.AbstractFactory;
using Factories.AbstractFactoryOCP;
using Factories.AsynchronousFactory;
using Factories.Factory;
using Factories.FactoryMethod;
using Factories.InnerFactory;
using Factories.ObjectTracking;

namespace Factories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FactoryTest.Run();
            //AsynchronousFactoryTest.Run();
            //ObjectTrackingTest.Run();
            //InnerFactoryTest.Run();
            //AbstractFactoryTest.Run();
            //FactoryMethodTest.Run();
            AbstractFactoryOCPTest.Run();
        }
    }
}