using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.StepwiseBuilder
{
    public enum CarType
    {
        Sedan,
        Crossover
    }

    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }

    public interface ISpecifyWheelSize
    {
        IBuilderCar WithWheels(int size);
    }

    public interface IBuilderCar
    {
        public Car Build();
    }

    public class CardBuilder
    {
        private class Impl : ISpecifyCarType, ISpecifyWheelSize, IBuilderCar
        {
            private Car car = new Car();

            public Car Build()
            {
                return car;
            }

            public IBuilderCar WithWheels(int size)
            {
                switch (car.Type)
                {
                    case CarType.Crossover when size < 17 || size > 20:
                    case CarType.Sedan when size < 15 || size > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.Type}.");

                }
                car.WheelSize = size;
                return this;
            }

            ISpecifyWheelSize ISpecifyCarType.OfType(CarType type)
            {
                car.Type = type;
                return this;
            }
        }


        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }


    public class Car
    {
        public CarType Type { get; set; }

        public int WheelSize { get; set; }
    }



}
