using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace binarysearch
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
                input.Add(i);
            }

            Console.WriteLine($"Search a random number between 0 and {capacity}:");
            var value = int.Parse(Console.ReadLine());

            Console.WriteLine("Searching...");
            ClearMemory();

            stopwatch.Start();
            var result = BinarySearch(value, input);
            stopwatch.Stop();

            if (result == value)
                Console.WriteLine("Bingo!");
            else
                Console.WriteLine("Couldn't find");

            Console.WriteLine($"{stopwatch.Elapsed.TotalMilliseconds}ms");
        }

        private static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private static int BinarySearch(int value, List<int> collection)
        {
            if (collection.Count == 1 && collection[0] == value)
                return value;

            var lowerBound = 0;
            var upperBound = collection.Count;

            var ticks = 0;

            while (lowerBound < upperBound)
            {
                ticks++;

                var middleIndex = lowerBound + (upperBound - lowerBound) / 2;

                if (collection[middleIndex]==value)
                {
                    Console.WriteLine($"Found in {ticks} ticks");
                    return middleIndex;
                }
                else if (collection[middleIndex] < value)
                {
                    lowerBound = middleIndex + 1;
                }   
                else
                {
                    upperBound = middleIndex;
                } 
            }

            return -1;
        }
    }
}
