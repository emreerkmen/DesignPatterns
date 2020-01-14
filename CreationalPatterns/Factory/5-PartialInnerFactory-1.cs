using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Factory
{
    /*If you don’t like the idea of having the entire definition of the Factory
    being placed into your Point.cs file, you can use the partial keyword
    because—guess what—it works on inner classes, too. First, in Point.cs,
    you would modify the Point type to now read
    public partial class Point { ... }
    Then, simply make a new file (e.g., Point.Factory.cs) and, inside it,
    define another part of Point; that is,*/
    public partial class PointPIF
    {
        private double x, y;
        // typical members here
        // note the constructor is again private
        private PointPIF(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
