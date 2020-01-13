using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Factory
{
    /*An inner factory is simply a factory that is an inner (nested) class within
    the type it creates. Inner factories exist because inner classes can access
    the outer class’s private members and, conversely, an outer class can
    access an inner class’s private members. This means that our PointIF class
    can also be defined as follows:*/
    public class PointIF
    {
        private double x, y;
        // typical members here
        // note the constructor is again private
        private PointIF(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static class Factory
        {
            public static PointIF NewCartesianPointIF(double x, double y)
            {
                return new PointIF(x, y); // using a private constructor
            }
            // similar for NewPolarPointIF()
        }

        class DemoIF
        {
            static void Main2(string[] args)
            {
                var point = PointIF.Factory.NewCartesianPointIF(2, 3);
            }
        }

    }
}
