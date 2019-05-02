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
        ArraySort = 2,
    }

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
                NameSorter nameSorter = null;
                //Console.ForegroundColor = ConsoleColor.Cyan;
                //Console.WriteLine($"{sortMethod}\n");
                //Console.ForegroundColor = ConsoleColor.White;
                switch (sortMethod)
                {
                    case SortMethod.ArraySort:
                        nameSorter = new ArrayNameSorter();
                        break;
                    case SortMethod.QuickSort:
                        nameSorter = new QuickNameSorter();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"sortMethod: {sortMethod}");
                }                
                nameSorter.MainMethod(filename);

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
            if (args.Length == 2 && args[1].ToLower() == "quicksort")
            {
                return SortMethod.QuickSort;
            }
            if (args.Length == 2 && args[1].ToLower() == "arraysort")
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
            if (args.Length > 2) {
                return false;
            }
            if(args.Length == 2 && args[1].ToLower() != "quicksort" && args[1].ToLower() != "arraysort")
            {
                return false;
            }
            return true;
        }        

        private static void PrintUsage()
        {
            Console.WriteLine("\nUSAGE");
            Console.WriteLine("\tname-sorter <filename> [<algorithm>]");
            Console.WriteLine("\nOPTIONAL ALGORITHMS");
            Console.WriteLine("\tQuickSort\tQuickSort algorithm");
            Console.WriteLine("\tArraySort\t.NET Array Sort algorithm (this is the default algorithm");
            Console.WriteLine("");
        }
    }
}
