using System;
using System.Linq;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            char[][] maze  = new char[numberOfRows][];

            int numberofCols = 0;

            for(int i = 0; i < numberOfRows; i++)
            {
                string temp = Console.ReadLine();
                maze[i] = new char[temp.Length];
                maze[i] = temp.ToCharArray();
                numberofCols = temp.Length;
            }


            while (lives > 0)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                char direction = char.Parse(command[0]);

                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);

                maze[enemyRow][enemyCol] = 'B';

                int[] position = FindThePositionOfMario(maze, numberofCols);
                int currentRow = position[0];
                int currentCol = position[1];

                bool thereIsEnemy = false;
                bool princesFound = false;
                switch (direction)
                {
                    case 'W':
                        if (currentRow - 1 >= 0)
                        {
                            maze[currentRow] [currentCol] = '-';
                            currentRow--;
                            if (maze[currentRow][currentCol] == 'B') thereIsEnemy = true;
                            if (maze[currentRow][currentCol] == 'P')
                            {
                                maze[currentRow][currentCol] = '-';
                                princesFound = true;
                                lives--;
                                break;
                            }
                            maze[currentRow][currentCol] = 'M';
                            lives--;
                        }
                        else
                        {
                            lives--;
                        }
                        break;
                    case 'S':
                        if (currentRow + 1 < numberOfRows)
                        {
                            maze[currentRow][currentCol] = '-';
                            currentRow++;
                            if (maze[currentRow][currentCol] == 'B') thereIsEnemy = true;
                            if (maze[currentRow][currentCol] == 'P')
                            {
                                maze[currentRow][currentCol] = '-';
                                princesFound = true;
                                lives--;
                                break;
                            }
                            maze[currentRow][currentCol] = 'M';
                            lives--;
                        }
                        else
                        {
                            lives--;
                        }
                        break;
                    case 'A':
                        if (currentCol - 1 >= 0)
                        {
                            maze[currentRow][currentCol] = '-';
                            currentCol--;
                            if (maze[currentRow][currentCol] == 'B') thereIsEnemy = true;
                            if (maze[currentRow][currentCol] == 'P')
                            {
                                maze[currentRow][currentCol] = '-';
                                princesFound = true;
                                lives--;
                                break;
                            }
                            maze[currentRow][currentCol] = 'M';
                            lives--;
                        }
                        else
                        {
                            lives--;
                        }
                        break;

                    case 'D':
                        if (currentCol + 1 < numberofCols)
                        {
                            maze[currentRow][currentCol] = '-';
                            currentCol++;
                            if (maze[currentRow][currentCol] == 'B') thereIsEnemy = true;
                            if (maze[currentRow][currentCol] == 'P')
                            {
                                maze[currentRow][currentCol] = '-';
                                princesFound = true;
                                lives--;
                                break;
                            }
                            maze[currentRow][currentCol] = 'M';
                            lives--;
                        }
                        else
                        {
                            lives--;
                        }
                        break;
                    default:
                        break;
                }

                if (princesFound)
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }
                if (thereIsEnemy)
                {
                    lives -= 2;
                }
                if (lives <= 0)
                {
                    maze[currentRow][currentCol] = 'X';
                    Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
                    break;
                }
            }

            PrintTheMaze(maze,numberOfRows, numberofCols);
        }

        private static void PrintTheMaze(char[][] maze,int numberOfRows,int numberofCols)
        {
            for(int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberofCols; j++)
                {
                    Console.Write(maze[i][j]);
                }
                Console.WriteLine();
            }
        }

        public static int[] FindThePositionOfMario(char[][] maze, int numberofCols)
        {
            int[] result = new int[2];
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for(int j = 0; j < numberofCols; j++)
                {
                    if (maze[i][j] == 'M')
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
