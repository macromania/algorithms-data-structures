using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace mergesort
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

            var ticks = 0;
            stopwatch.Start();
            var sorted = MergeSort(input, ref ticks);
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

        static List<int> MergeSort(List<int> unsorted, ref int ticks)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            var halfOfUnsorted = unsorted.Count / 2;
            var left = unsorted.Take(halfOfUnsorted).ToList();
            var right = unsorted.Skip(halfOfUnsorted).ToList();

            ticks++;

            left = MergeSort(left, ref ticks);
            right = MergeSort(right, ref ticks);
            return Merge(left, right);
        }

        static List<int> Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }

            return result;
        }
    }
}
