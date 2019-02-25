using System;
using System.Collections.Generic;

namespace graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]
            {
                Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(2,6),
                Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7),
                Tuple.Create(5,7), Tuple.Create(5,8), Tuple.Create(5,6),
                Tuple.Create(8,9),
                Tuple.Create(9,10)
            };

            var graph = new Graph<int>(vertices, edges);
            Console.WriteLine(string.Join(", ", BFS(graph, 1)));
        }

        public static HashSet<T> BFS<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }
    }

}
