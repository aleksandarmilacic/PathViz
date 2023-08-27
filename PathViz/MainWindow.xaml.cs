using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PathViz
{
    public partial class MainWindow : Window
    {
        private Button[,] gridButtons;
        private Button startButton;
        private Button endButton;
        private Button resetButton;
        private int[,] grid;
        private int rows = 5;
        private int cols = 5;
        private PathFinderService pathFinderService;

        public MainWindow()
        {
            InitializeComponent();
            pathFinderService = new PathFinderService(5, 5); // Initialize it
            InitializeGrid();
            InitializeResetButton();
        }

        private void InitializeResetButton()
        {
            resetButton = new Button
            {
                Content = "Reset",
                Width = 100,
                Height = 40
            };
            resetButton.Click += ResetButton_Click;
            // Add this button somewhere in your XAML Grid or wherever you're placing buttons
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset grid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = 0;
                    gridButtons[i, j].Background = Brushes.LightGray;
                }
            }

            // Reset start and end buttons
            if (startButton != null)
            {
                startButton.Background = Brushes.LightGray;
            }

            if (endButton != null)
            {
                endButton.Background = Brushes.LightGray;
            }

            startButton = null;
            endButton = null;
        }

        private void InitializeGrid()
        {
            grid = new int[rows, cols];
            gridButtons = new Button[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Button button = new Button
                    {
                        Background = Brushes.LightGray
                    };

                    button.Click += GridButton_Click;

                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    mainGrid.Children.Add(button);

                    gridButtons[row, col] = button;
                }
            }
        }

        private (int, int) GetGridPosition(Button button)
        {
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);
            return (row, col);
        }

        private void GridButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            var pos = GetGridPosition(clickedButton);

            if (startButton == null)
            {
                clickedButton.Background = Brushes.Blue;
                startButton = clickedButton;
                grid[pos.Item1, pos.Item2] = -1;  // Marking start point on the grid
            }
            else if (endButton == null && clickedButton != startButton)
            {
                clickedButton.Background = Brushes.Red;
                endButton = clickedButton;
                grid[pos.Item1, pos.Item2] = -2;  // Marking end point on the grid
            }
            else if (clickedButton != startButton && clickedButton != endButton)
            {
                clickedButton.Background = Brushes.Black;
                grid[pos.Item1, pos.Item2] = 1;  // Marking obstacle on the grid
            }
        }


        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            if (startButton != null && endButton != null)
            {
                var start = GetGridPosition(startButton);
                var end = GetGridPosition(endButton);
                pathFinderService.Grid = this.grid; // Set the grid from MainWindow to PathFinderService

                bool isPathFound = pathFinderService.RunDijkstra(start, end);

                if (isPathFound)
                {
                    MessageBox.Show("Path found!");
                }
                else
                {
                    MessageBox.Show("No path found!");
                }
            }
            else
            {
                MessageBox.Show("Please set both start and end points.");
            }
        }



    }
}
