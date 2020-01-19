using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Singleton
{
    public class MyDatabase
    {
        /*This is also a thread-safe approach because the objects Lazy<T> creates
        are thread-safe by default. In a multithreaded setting, the first thread to
        access the Value property of a Lazy<T> is the one that initializes it for all
        subsequent accesses on all threads.*/
        private MyDatabase()
        {
            Console.WriteLine("Initializing database");
        }
        private static Lazy<MyDatabase> instance = new Lazy<MyDatabase>(() => new MyDatabase());
        public static MyDatabase Instance => instance.Value;
    }
}
