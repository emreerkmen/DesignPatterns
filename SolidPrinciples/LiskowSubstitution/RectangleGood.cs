using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SolidPrinciples.LiskowSubstitution
{
    // using a classic example
    public class RectangleGood
    {
        //public int Width { get; set; }
        //public int Height { get; set; }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public RectangleGood()
        {

        }

        public RectangleGood(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class SquareGood : RectangleGood
    {
        //public new int Width
        //{
        //  set { base.Width = base.Height = value; }
        //}

        //public new int Height
        //{ 
        //  set { base.Width = base.Height = value; }
        //}

        public override int Width // nasty side effects
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

    public class Demo
    {
        static public int Area(RectangleGood r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            RectangleGood rc = new RectangleGood(2, 3);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            // should be able to substitute a base type for a subtype
            /*Square*/
            RectangleGood sq = new SquareGood();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}
