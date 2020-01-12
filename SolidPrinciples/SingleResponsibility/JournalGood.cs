using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DesignPatterns.SolidPrinciples.SingleResponsibility
{
    public class JournalGood
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
    }

    // handles the responsibility of persisting objects
    public class Persistence
    {
        public void SaveToFile(JournalGood journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }
    public class DemoGood
    {
        static void Main2(string[] args)
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
