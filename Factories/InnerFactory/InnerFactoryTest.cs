namespace Factories.InnerFactory
{
    public class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point Origin = new Point(0, 0);

        //public static PointFactory Factory => new PointFactory();
        
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }

    }


    public class InnerFactoryTest
    {
        public static void Run()
        {
            var point1 = Point.Factory.NewCartesianPoint(10.0, 20.0);
            var point2 = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);

        }
    }
}
