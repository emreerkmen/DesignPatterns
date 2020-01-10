using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SolidPrinciples.OpenExtClosedMod
{
    //public enum Color
    //{
    //    Red, Green, Blue
    //}

    //public enum Size
    //{
    //    Small, Medium, Large, Yuge
    //}

    public class ProductGood
    {
        public string Name;
        public Color Color;
        public Size Size;

        public ProductGood(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;
        }
    }

    // we introduce two new interfaces that are open for extension

    public interface ISpecification<T>
    {
        bool IsSatisfied(ProductBad p);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<ProductBad>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(ProductBad p)
        {
            return p.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<ProductBad>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(ProductBad p)
        {
            return p.Size == size;
        }
    }

    // combinator
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool IsSatisfied(ProductBad p)
        {
            return first.IsSatisfied(p) && second.IsSatisfied(p);
        }
    }

    public class BetterFilter : IFilter<ProductBad>
    {
        public IEnumerable<ProductBad> Filter(IEnumerable<ProductBad> items, ISpecification<ProductBad> spec)
        {
            foreach (var i in items)
                if (spec.IsSatisfied(i))
                    yield return i;
        }
    }

    public class DemoGood
    {
        static void Main(string[] args)
        {
            var apple = new ProductBad("Apple", Color.Green, Size.Small);
            var tree = new ProductBad("Tree", Color.Green, Size.Large);
            var house = new ProductBad("House", Color.Blue, Size.Large);

            ProductBad[] products = { apple, tree, house };

            var bf = new BetterFilter();
            Console.WriteLine("Green products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
                Console.WriteLine($" - {p.Name} is green");

            Console.WriteLine("Large products");
            foreach (var p in bf.Filter(products, new SizeSpecification(Size.Large)))
                Console.WriteLine($" - {p.Name} is large");

            Console.WriteLine("Large blue items");
            foreach (var p in bf.Filter(products,
              new AndSpecification<ProductBad>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large)))
            )
            {
                Console.WriteLine($" - {p.Name} is big and blue");
            }
        }
    }
}
