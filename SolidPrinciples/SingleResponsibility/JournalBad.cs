using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DesignPatterns.SolidPrinciples.SingleResponsibility
{
    public class JournalBad
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern!
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // breaks single responsibility principle
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }
    public class DemoBad
    {
        static void Main(string[] args)
        {
            var j = new JournalGood();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename);
            Process.Start(filename);
        }
    }
}
