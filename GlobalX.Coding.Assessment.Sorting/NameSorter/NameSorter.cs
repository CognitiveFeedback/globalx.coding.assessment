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

        /// <summary>
        /// Load name from the file given by filename
        /// </summary>
        /// <param name="filename">full path to a file containing the correct format for names</param>
        public virtual void LoadNames(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"The file {filename} cannot be found");
            }
            try
            {
                names = GetNames(filename);
            }
            catch (ArgumentException)
            {
                throw new Exception("The file is not correctly formatted. The file must only contain a list of full names where each full name consts of 1 to 3 given names followed by a family name.");
            }
            catch (Exception)
            {
                throw new Exception("Unkown error occured.");
            }
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
