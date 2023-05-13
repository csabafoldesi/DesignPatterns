using System.Text;
using Builder.FacetedBuilder;
using Builder.FluentBuilder;
using Builder.FluentBuilderInheritance;
using Builder.FunctionalBuilder;
using Builder.StepwiseBuilder;

namespace Builder
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            /*
            // FluentBuilder
            var builder = new HtmlBuilder("ul");
            builder
                .AddChild("li", "Hello")
                .AddChild("li", "World");
            Console.WriteLine(builder.ToString());

            // FluentBuilderInheritance
            var me = Person
                .New
                .Called("Csabus")
                .WorksAsA("Worker")
                .Build();
            Console.WriteLine(me);

            // StepwiseBuilder
            var car = CardBuilder.Create() // ISpecifyCarType
                .OfType(CarType.Crossover) // ISPecifyWheelSize
                .WithWheels(18)            // IBuildCar
                .Build();*/

            //RunTest("FunctionalBuilder");
            RunTest("FacetedBuilder");

        }

        static void RunTest(string testName)
        {
            switch (testName)
            {
                case "FunctionalBuilder":
                    FunctionalBuilderTest.Run();
                    break;
                case "FacetedBuilder":
                    FacetedBuilderTest.Run();
                    break;
                default:
                    break;
            }
        }
    }
}