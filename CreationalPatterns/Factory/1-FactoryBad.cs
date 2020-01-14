using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Factory
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }


    public class Point
    {
        private double x, y;
        //public Point(double x, double y)
        //{
        //    this.x = x;
        //    this.y = y;
        //}
        //public Point(float r, float theta)
        //{
        //    x = r * Math.Cos(theta);
        //    y = r * Math.Sin(theta);
        //}

        /*Overall, our constructor design is usable, but ugly. In particular, to
        add some third co ordinate system, for example, you would need to do the
        following:
        • Give CoordinateSystem a new enumeration value.
        • Change the constructor to support the new coordinate
        system.
        There must be a better way of doing this.*/
        public Point(double a, double b, // names do not communicate intent
                    CoordinateSystem cs = CoordinateSystem.Cartesian)
        {
            switch (cs)
            {
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    x = a;
                    y = b;
                    break;
            }
        }
    }

    class DemoBadFactory 
    {
        static void Main2(string[] args)
        {
            Point point = new Point(123.04, 123.04);
        }
    }
}
