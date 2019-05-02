using GlobalX.Coding.Assessment.Sorting.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GlobalX.Coding.Assessment.Sorting.NameSorter
{
    public abstract class NameSorter
    {
        protected Name[] names = null;
        protected Stopwatch sw = new Stopwatch();

        public void LoadNames(string filename)
        {
            if (!File.Exists(filename))
            {
                FileNotFound();
                return;
            }
            names = GetNames(filename);
        }

        private void FileNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nFile Not Found");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static Name[] GetNames(string filename)
        {
            var names = File.ReadAllLines(filename);
            var result = names.Select(a => new Name(a)).ToArray();
            return result;
        }

        public void WriteOutput()
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            File.WriteAllLines("sorted-names-list.txt", names.Select(a => a.ToString()).ToArray());
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine($"\nTime taken {sw.ElapsedMilliseconds} ms");
            //Console.ForegroundColor = ConsoleColor.White;
        }

        public abstract void Sort();
    }
}
