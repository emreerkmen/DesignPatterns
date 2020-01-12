using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SolidPrinciples.OpenExtClosedMod
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuge
    }

    public class ProductBad
    {
        public string Name;
        public Color Color;
        public Size Size;

        public ProductBad(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        // let's suppose we don't want ad-hoc queries on products
        public IEnumerable<ProductBad> FilterByColor(IEnumerable<ProductBad> products, Color color)
        {
            foreach (var p in products)
                if (p.Color == color)
                    yield return p;
        }

        public static IEnumerable<ProductBad> FilterBySize(IEnumerable<ProductBad> products, Size size)
        {
            foreach (var p in products)
                if (p.Size == size)
                    yield return p;
        }

        public static IEnumerable<ProductBad> FilterBySizeAndColor(IEnumerable<ProductBad> products, Size size, Color color)
        {
            foreach (var p in products)
                if (p.Size == size && p.Color == color)
                    yield return p;
        } // state space explosion
          // 3 criteria = 7 methods

        // OCP = open for extension but closed for modification
    }

    public class DemoBad
    {
        static void Main2(string[] args)
        {
            var apple = new ProductBad("Apple", Color.Green, Size.Small);
            var tree = new ProductBad("Tree", Color.Green, Size.Large);
            var house = new ProductBad("House", Color.Blue, Size.Large);

            ProductBad[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Console.WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
                Console.WriteLine($" - {p.Name} is green");
        }
    }
}
