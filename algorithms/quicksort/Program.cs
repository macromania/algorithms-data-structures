using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            Console.WriteLine("Enter Capacity");
            var capacityInput = Console.ReadLine();


            int.TryParse(capacityInput, out int capacity);
            capacity = capacity > 1_000_000 || capacity == 0 ? 1_000 : capacity;

            Console.WriteLine("Generating...");

            var random = new Random();
            var input = new List<int>();
            for (var i = 0; i < capacity; i++)
            {
                input.Add(random.Next(0, 1_000));
            }

            Console.WriteLine("Sorting...");
            ClearMemory();
            
            stopwatch.Start();
            var sorted = input.OrderBy(i => i).ToList();
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.Elapsed.TotalMilliseconds}ms");
            ClearMemory();

            stopwatch.Start();
            var ticks = 0;
            input = QuickSort(input, ref ticks);
            stopwatch.Stop();
            Console.WriteLine($"Sorted in {ticks} ticks");
            Console.WriteLine($"{stopwatch.Elapsed.TotalMilliseconds}ms");
        }

        private static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        static List<int> QuickSort(List<int> collection, ref int ticks)
        {
            if (collection.Count <= 1) 
                return collection;

            int pivotPosition = collection.Count / 2;
            int pivotValue = collection[pivotPosition];

            collection.RemoveAt(pivotPosition);

            var smallerValues = collection.Where(i => i < pivotValue).ToList();
            var greaterValues = collection.Where(i => i > pivotValue).ToList();

            ticks++;

            var sorted = QuickSort(smallerValues, ref ticks);
            sorted.Add(pivotValue);
            sorted.AddRange(QuickSort(greaterValues, ref ticks));
            return sorted;
        }
    }

}
