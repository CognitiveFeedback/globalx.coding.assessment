using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GlobalX.Coding.Assessment.Sorting
{
    public enum SortMethod
    {
        None = 0,
        QuickSort = 1,
        Enumerable = 2,
    }

    public class Program
    {
        private static Process process = null;
        private static void Main(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                PrintUsage();
                return;
            }

            try
            {
                var filename = args[0];
                var method = args.Length == 2 && args[1].ToLower() == "quicksort" ? SortMethod.QuickSort : SortMethod.Enumerable;
                MainMethod(filename, method);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadKey();
            process.Kill();
        }

        private static void MainMethod(string filename, SortMethod sortMethod)
        {
            if (!File.Exists(filename))
            {
                FileNotFound();
                return;
            }

            var names = GetNames(filename);

            IEnumerable<Name> sortedNames = null;
            switch (sortMethod)
            {
                case SortMethod.Enumerable:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("EnumerableSort\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    sortedNames = EnumerableSort(names);
                    break;
                case SortMethod.QuickSort:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("QuickSort\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    sortedNames = QuickSort(names);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"sortMethod: {sortMethod}");
            }

            WriteList(sortedNames);
        }

        private static void FileNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nFile Not Found");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static IEnumerable<Name> EnumerableSort(IEnumerable<Name> names)
        {
            var sortedNames = QuickSort<Name>.Sort(names);
            return sortedNames;
        }

        public static IEnumerable<Name> QuickSort(IEnumerable<Name> names)
        {
            var sortedNames = names.ToList();
            sortedNames.Sort();
            return sortedNames;
        }

        private static List<Name> GetNames(string filename)
        {
            var names = File.ReadAllLines(filename);
            var result = new List<Name>();
            foreach (var name in names)
            {
                var item = new Name(name);
                result.Add(item);
            }
            return result;
        }

        private static void WriteList(IEnumerable<Name> lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            File.WriteAllLines("sorted-names-list.txt", lines.Select(a => a.ToString()).ToArray());
            process = Process.Start(new ProcessStartInfo() { FileName = "sorted-names-list.txt" });
        }

        private static void PrintUsage()
        {
            Console.WriteLine("\nUSAGE");
            Console.WriteLine("\tname-sorter [filename]");
            Console.WriteLine("");
        }
    }
}
