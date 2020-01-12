using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SolidPrinciples.LiskowSubstitution
{
    // using a classic example
    public class RectangleBad
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public RectangleBad()
        {

        }

        public RectangleBad(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class SquareBad : RectangleBad
    {
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }

        public new int Height
        {
            set { base.Width = base.Height = value; }
        }

    }

    public class DemoBad
    {
        static public int Area(RectangleBad r) => r.Width * r.Height;

        static void Main2(string[] args)
        {
            RectangleBad rc = new RectangleBad(2, 3);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            // should be able to substitute a base type for a subtype
            /*Square*/
            RectangleBad sq = new SquareBad();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}
