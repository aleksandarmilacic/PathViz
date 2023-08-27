using System;
using Xunit;

namespace PathViz.Tests
{ 
    public class PathFinderServiceTests
    {
        private PathFinderService _service;
        private const int Rows = 5;
        private const int Cols = 5;

        public PathFinderServiceTests()
        {
            _service = new PathFinderService(Rows, Cols);
        }

        private void SetupGridWithObstacles(params (int, int)[] obstacles)
        {
            foreach (var (row, col) in obstacles)
            {
                _service.Grid[row, col] = 1; // Mark as obstacle
            }
        }

        [Theory]
        [InlineData(0, 0, 4, 4, true, -1, -1)]  // No obstacles
        [InlineData(0, 0, 4, 4, false, 1, 0, 0, 1)]  // With obstacles
        public void Test_RunDijkstra(int startX, int startY, int endX, int endY, bool expectedResult, params int[] obstacles)
        {
            // Convert the flat list of integers into a list of tuples
            var obstacleTuples = new List<(int, int)>();
            for (int i = 0; i < obstacles.Length; i += 2)
            {
                if (obstacles[i] != -1 && obstacles[i + 1] != -1)  // -1, -1 means no obstacle
                {
                    obstacleTuples.Add((obstacles[i], obstacles[i + 1]));
                }
            }

            // Arrange
            SetupGridWithObstacles(obstacleTuples.ToArray());
            var start = (startX, startY);
            var end = (endX, endY);

            // Act
            var result = _service.RunDijkstra(start, end);

            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
