using System;
using System.Collections.Generic;

namespace PathViz
{
    public class PathFinderService
    {
        public int[,] Grid { get; set; }
        private int rows;
        private int cols;

        public PathFinderService(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            Grid = new int[rows, cols];
        }

        public bool RunDijkstra((int, int) start, (int, int) end)
        {
            int[,] dist = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    dist[i, j] = int.MaxValue;
                }
            }

            dist[start.Item1, start.Item2] = 0;
            var toVisit = new Queue<(int, int)>();
            toVisit.Enqueue(start);

            while (toVisit.Count > 0)
            {
                var current = toVisit.Dequeue();
                if (current == end)
                {
                    return true;
                }

                foreach (var dir in new[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
                {
                    var newX = current.Item1 + dir.Item1;
                    var newY = current.Item2 + dir.Item2;

                    if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && Grid[newX, newY] != 1)
                    {
                        var newDist = dist[current.Item1, current.Item2] + 1;
                        if (newDist < dist[newX, newY])
                        {
                            dist[newX, newY] = newDist;
                            toVisit.Enqueue((newX, newY));
                        }
                    }
                }
            }

            return false;
        }
    }
}
