using System;
using System.Collections.Generic;
using System.Linq;

namespace binarysearchtree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Comma Seperated Tree Nodes:");
            var nodeInputs = Console.ReadLine().Split(",").ToList();
            var nodes = new List<int>();
            nodeInputs.ForEach((nodeInput) => nodes.Add(int.Parse(nodeInput)));

            var tree = new BinarySearchTree(nodes);
            if(tree.Left != null && tree.Left.IsRoot)
                tree.Left?.Print();
            else
                tree.Right?.Print();


            Console.WriteLine("Search Tree:");
            var value = int.Parse(Console.ReadLine());

            var searchResult = tree.Search(value);
            if (searchResult != null)
                searchResult.Print();
            else
                Console.WriteLine($"Couldn't find {value}");

            Console.WriteLine("Traversing In Order");
            tree.Traverse(TraverseOrder.In);

            Console.WriteLine("Traversing Pre Order");
            tree.Traverse(TraverseOrder.Pre);

            Console.WriteLine("Traversing Post Order");
            tree.Traverse(TraverseOrder.Post);
        }
    }
}
