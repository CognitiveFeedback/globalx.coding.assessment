using GlobalX.Coding.Assessment.Sorting.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GlobalX.Coding.Assessment.Sorting.NameSorter
{
    /// <summary>
    /// Abstract class defining loading and output lgic and an abstract method for Sort
    /// </summary>
    public abstract class NameSorter
    {
        protected OrderedName[] names = null;
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

        private static OrderedName[] GetNames(string filename)
        {
            var names = File.ReadAllLines(filename);
            var result = names.Select(a => new OrderedName(a)).ToArray();
            return result;
        }

        /// <summary>
        /// Output the list of names in this case to the console and an output file.
        /// </summary>
        public virtual void WriteOutput()
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
