using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Singleton
{
    public class ChiefExecutiveOfficer
    {
        private static string name;/*Static*/
        private static int age;/*Static*/
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }
    }
}
