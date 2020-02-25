using System;
using System.Collections.Generic;

namespace QLearningTest
{
    class MazeGenerator
    {
        private struct Cell
        {
            public readonly int x;
            public readonly int y;

            public Cell(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private MazeGenerator()
        {

        }

        public static int[,] GenerateMaze(int width, int height)
        {
            if ((width % 2 != 1) || (height % 2 != 1))
            {
                string message = "Maze can't have even width or height";
                throw new ArgumentException(message);
            }

            int[,] maze = new int[width, height];
            Cell curCell = new Cell(1, 1);
            Stack<Cell> stack = new Stack<Cell>();

            //0 = unvisited empty
            //1 = visited empty
            //2 = wall
            maze[curCell.x, curCell.y] = 1;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ( (i % 2 == 0) || (j % 2 == 0) )
                    {
                        //Only leave cells with both x and y uneven empty
                        //This creates a grid that we'll use to generate
                        //the maze
                        maze[i, j] = 2;
                    }
                }
            }

            Random rng = new Random();
            while (true)
            {
                List<Cell> unvisitedNeighbors =
                    GetUnvisitedNeighbors(curCell, maze);
                Console.WriteLine(curCell.x + "," + curCell.y);

                if (unvisitedNeighbors.Count != 0)
                {
                    stack.Push(curCell);
                    int cellToVisitIndex = rng.Next(unvisitedNeighbors.Count);
                    Cell cellToVisit = unvisitedNeighbors[cellToVisitIndex];

                    CutWallBetween(curCell, cellToVisit, maze);
                    curCell = cellToVisit;
                    maze[curCell.x, curCell.y] = 1;
                }
                else if (stack.Count != 0)
                {
                    curCell = stack.Pop();
                }
                else
                {
                    break;
                }
            }

            return maze;
        }

        private static List<Cell> GetUnvisitedNeighbors(Cell curCell, int[,] maze)
        {
            List<Cell> result = new List<Cell>();
            int x = curCell.x;
            int y = curCell.y;
            int cols = maze.GetLength(0);
            int rows = maze.GetLength(1);

            if ((x > 1) && (maze[x - 2, y] == 0))
            {
                result.Add(new Cell(x - 2, y));
            }
            if ((y > 1) && (maze[x, y - 2] == 0))
            {
                result.Add(new Cell(x, y - 2));
            }
            if ((x < cols - 2) && (maze[x + 2, y] == 0))
            {
                result.Add(new Cell(x + 2, y));
            }
            if ((y < rows - 2) && (maze[x, y + 2] == 0))
            {
                result.Add(new Cell(x, y + 2));
            }

            return result;
        }

        private static void CutWallBetween(Cell c1, Cell c2, int[,] maze)
        {
            maze[(c1.x + c2.x) / 2, (c1.y + c2.y) / 2] = 1;
        }
    }
}
