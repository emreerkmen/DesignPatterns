using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Factory
{
    /*Seperate factory methods with classes*/
    public class PointF
    {
        private double x, y;

        /*Whenever you want to prevent a client from accessing something, I always
        recommend you make it protected rather than private because then you make
        the class inheritance-friendly.*/
        public PointF(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class PointFactoryF
    {
        public static PointF NewCartesianPoint(double x, double y)
        {
            return new PointF(x, y);
        }
        public static PointF NewPolarPoint(double rho, double theta)
        {
            return new PointF(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
        // other members omitted
    }


    class DemoF
    {
        static void Main2(string[] args)
        {
            var point = PointFactoryF.NewCartesianPoint(5, Math.PI / 4);
        }
    }
}
