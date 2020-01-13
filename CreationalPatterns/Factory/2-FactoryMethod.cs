using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Factory
{
    public class PointFM
    {
        private double x, y;

        /*Whenever you want to prevent a client from accessing something, I always
        recommend you make it protected rather than private because then you make
        the class inheritance-friendly.*/
        protected PointFM(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static PointFM NewCartesianPoint(double x, double y)
        {
            return new PointFM(x, y);
        }
        public static PointFM NewPolarPoint(double rho, double theta)
        {
            return new PointFM(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
        // other members omitted
    }

    class DemoFM
    {
        static void Main2(string[] args)
        {
            var point = PointFM.NewPolarPoint(5, Math.PI / 4);
        }
    }
}
