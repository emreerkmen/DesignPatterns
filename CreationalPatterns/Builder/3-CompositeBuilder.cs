using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Builder
{
    //    There is one fairly obvious downside to this approach: it is not extensible.
    //Generally speaking, it is a bad idea for a base class to be aware of its own
    //subclasses, yet this is precisely what is happening here: PersonBuilder is
    //aware of its own children by exposing them through special APIs.If you
    //wanted to have an additional subbuilder (say, a PersonEarningsBuilder),
    //you would have to break OCP and edit PersonBuilder directly; you cannot
    //simply subclass it to add an interface member.
    public class Person
    {
        // address
        public string StreetAddress, Postcode, City;
        // employment info
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Adress: {StreetAddress}, {Postcode}, {City}");
            sb.AppendLine($"Company: {CompanyName}, {Position}, {AnnualIncome}");

            return sb.ToString();
        }
    }

    public class PersonBuilder
    {
        // the object we're going to build
        protected Person person; // this is a reference!
        public PersonBuilder() => person = new Person();
        protected PersonBuilder(Person person) => this.person = person;
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }

        public override string ToString() => person.ToString();
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person) : base(person)
        {
            this.person = person;
        }
        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }
        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }
        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    };
    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person) : base(person)
        {
            this.person = person;
        }
        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }
        public PersonJobBuilder Earning(int annualIncome)
        {
            person.AnnualIncome = annualIncome;
            return this;
        }
    };

    class DemoComposite
    {
        static void Main2(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
             .Lives
             .At("123 London Road")
             .In("London")
             .WithPostcode("SW12BC")
             .Works
             .At("Fabrikam")
             .AsA("Engineer")
             .Earning(123000);

            Console.WriteLine(person);
        }
    }
}
