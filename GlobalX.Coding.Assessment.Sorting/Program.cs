using GlobalX.Coding.Assessment.Sorting.NameSorter;
using System;

namespace GlobalX.Coding.Assessment.Sorting
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (!IsCommandLineValid(args))
            {
                PrintUsage();
                Console.WriteLine("\n\nPress any key to exit.");
                Console.ReadKey();
                return;
            }

            try
            {
                var filename = args[0];
                var sortMethod = GetSortMethod(args);

                var nameSorter = NameSorterFactory.Create(sortMethod);
                nameSorter.LoadNames(filename);
                nameSorter.Sort();
                nameSorter.WriteOutput();

#if DEBUG
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nAlgorithm: {sortMethod}");
                Console.WriteLine($"Time taken to sort {nameSorter.Length} itmes: {nameSorter.ElapsedMilliseconds} ms");
                Console.ForegroundColor = ConsoleColor.White;
#endif
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadKey();
        }

        private static SortMethod GetSortMethod(string[] args)
        {
            if (args.Length == 2 && args[1].Equals("QuickSort", StringComparison.InvariantCultureIgnoreCase))
            {
                return SortMethod.QuickSort;
            }
            if (args.Length == 2 && args[1].Equals("ArraySort", StringComparison.InvariantCultureIgnoreCase))
            {
                return SortMethod.ArraySort;
            }
            return SortMethod.ArraySort;
        }

        private static bool IsCommandLineValid(string[] args)
        {
            if (args.Length < 1)
            {
                return false;
            }
            if (args.Length > 2)
            {
                return false;
            }
            if (args.Length == 2
                && !args[1].Equals("QuickSort", StringComparison.InvariantCultureIgnoreCase)
                && !args[1].Equals("ArraySort", StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            return true;
        }

        private static void PrintUsage()
        {
            Console.WriteLine("\nUSAGE");
            Console.WriteLine("\tname-sorter <filename> [<algorithm>]");
            Console.WriteLine("\nOPTIONAL SORTING ALGORITHMS");
            Console.WriteLine("\tQuickSort\tQuickSort algorithm");
            Console.WriteLine("\tArraySort\t.NET Array Sort algorithm (this is the default sorting algorithm)");
            Console.WriteLine("");
        }
    }
}
