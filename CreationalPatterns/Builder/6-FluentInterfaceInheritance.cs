using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Builder
{
    public class PersonFII
    {
        public string Name;
        public string Position;

        public class Builder : PersonJobBuilderFII<Builder>
        {
            internal Builder() { }
        }
        public static Builder New => new Builder();
    }

    public abstract class PersonBuilderFII
    {
        protected PersonFII person = new PersonFII();
        public PersonFII Build()
        {
            return person;
        }
    }

    //public class PersonInfoBuilderFII : PersonBuilderFII
    //{
    //    public PersonInfoBuilderFII Called(string name)
    //    {
    //        person.Name = name;
    //        return this;
    //    }
    //}

    /*Essentially, we are enforcing an inheritance chain: we
    are saying that Foo<Bar> is only an acceptable specialization if Foo derives
    from Bar, and all other cases should fail the where constraint.*/
    public class PersonInfoBuilderFII<SELF> : PersonBuilderFII where SELF : PersonInfoBuilderFII<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    //public class PersonJobBuilderFII : PersonInfoBuilderFII
    //{
    //    public PersonJobBuilderFII WorksAsA(string position)
    //    {
    //        person.Position = position;
    //        return this;
    //    }
    //}
    public class PersonJobBuilderFII<SELF> : PersonInfoBuilderFII<PersonJobBuilderFII<SELF>> where SELF : PersonJobBuilderFII<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }


    class DemoFII
    {
        static void Main2(string[] args)
        {
            /*Without SELF this not gone be compile*/
            var me = PersonFII.New
                     .Called("Dmitri")
                     .WorksAsA("Quant") // will not compile
                     .Build();
        }
    }
}
