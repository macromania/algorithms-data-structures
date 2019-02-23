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
            input = QuickSort(input);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.Elapsed.TotalMilliseconds}ms");
        }

        private static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        static List<int> QuickSort(List<int> collection)
        {
            if (collection.Count <= 1)
                return collection;

            var pivot = collection[collection.Count/2];
            var smallerThanPivot = collection.Where(i => i < pivot).ToList();
            var equalToPivot = collection.Where(i => i == pivot).ToList();
            var biggerThanPivot = collection.Where(i => i > pivot).ToList();
            
            return QuickSort(smallerThanPivot).Concat(equalToPivot).Concat(QuickSort(biggerThanPivot)).ToList();
        }
    }

}
