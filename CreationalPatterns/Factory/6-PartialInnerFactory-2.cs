using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Factory
{
    public partial class PointPIF
    {
        public static class Factory
        {
            public static PointPIF NewCartesianPointIF(double x, double y)
            {
                return new PointPIF(x, y); // using a private constructor
            }
            // similar for NewPolarPointIF()
        }
    }

    class DemoPIF
    {
        static void Main2(string[] args)
        {
            var point = PointPIF.Factory.NewCartesianPointIF(2, 3);
        }
    }
}
