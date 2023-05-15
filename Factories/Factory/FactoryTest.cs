namespace Factories.Factory
{
    public class Point
    {
        private double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public static class PointFactory
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

    public class FactoryTest
    {
        public static void Run()
        {
            var point1 = PointFactory.NewCartesianPoint(10.0, 20.0);
            var point2 = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
        }
    }
}
