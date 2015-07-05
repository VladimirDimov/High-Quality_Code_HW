namespace Mines
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private static void Main()
        {
            const int BRAKE_GAME_POINTS = 35;

            bool isOnBrakeGamePoints = false;
            bool showMenu = true;
            bool stepOnMine = false;
            char[,] minesPositions = PlaceMines();
            char[,] playingGrid = CreatePlayingGrid();
            int column = 0;
            int pointsCounter = 0;
            int row = 0;
            List<Player> champions = new List<Player>(6);
            string command = string.Empty;

            do
            {
                if (showMenu)
                {
                    Console.WriteLine("Let's play “Mines”. Try to find all fields without mines." +
                    "\n\nCommands:\n'top' => Shows standings\n'restart' => Start new game\n'exit' => Exit game!");
                    DrawPlayingGrid(playingGrid);
                    showMenu = false;
                }

                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();

                bool isValidCommand = int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) && row <= playingGrid.GetLength(0) && column <= playingGrid.GetLength(1);

                if (command.Length >= 3)
                {
                    if (isValidCommand)
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Standings(champions);
                        break;
                    case "restart":
                        playingGrid = CreatePlayingGrid();
                        minesPositions = PlaceMines();
                        DrawPlayingGrid(playingGrid);
                        stepOnMine = false;
                        showMenu = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye!");
                        break;
                    case "turn":
                        if (minesPositions[row, column] != '*')
                        {
                            if (minesPositions[row, column] == '-')
                            {
                                OpenCell(playingGrid, minesPositions, row, column);
                                pointsCounter++;
                            }

                            if (BRAKE_GAME_POINTS == pointsCounter)
                            {
                                isOnBrakeGamePoints = true;
                            }
                            else
                            {
                                DrawPlayingGrid(playingGrid);
                            }
                        }
                        else
                        {
                            stepOnMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command\n");
                        break;
                }

                if (stepOnMine)
                {
                    DrawPlayingGrid(minesPositions);
                    Console.Write("You stepped on a mine. You reached {0} points. " + "\nEnter your nickname: ", pointsCounter);
                    string nickname = Console.ReadLine();
                    Player player = new Player(nickname, pointsCounter);
                    if (champions.Count < 5)
                    {
                        champions.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < player.Points)
                            {
                                champions.Insert(i, player);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    champions.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    Standings(champions);

                    playingGrid = CreatePlayingGrid();
                    minesPositions = PlaceMines();
                    pointsCounter = 0;
                    stepOnMine = false;
                    showMenu = true;
                }

                if (isOnBrakeGamePoints)
                {
                    Console.WriteLine("\nCongratulations! You reached " + BRAKE_GAME_POINTS + " points.");
                    DrawPlayingGrid(minesPositions);
                    Console.WriteLine("Enter your name:");
                    string name = Console.ReadLine();
                    Player points = new Player(name, pointsCounter);
                    champions.Add(points);
                    Standings(champions);
                    playingGrid = CreatePlayingGrid();
                    minesPositions = PlaceMines();
                    pointsCounter = 0;
                    isOnBrakeGamePoints = false;
                    showMenu = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("Bye!.");
            Console.Read();
        }

        private static void Standings(List<Player> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty standings!\n");
            }
        }

        private static void OpenCell(char[,] playingGrid, char[,] mines, int row, int column)
        {
            int numberOfMines = GetSurroundingBombs(mines, row, column);
            mines[row, column] = ConvertIntToChar(numberOfMines);
            playingGrid[row, column] = ConvertIntToChar(numberOfMines);
        }

        private static void DrawPlayingGrid(char[,] board)
        {
            int numberOfRows = board.GetLength(0);
            int numberOfColumns = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < numberOfRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < numberOfColumns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayingGrid()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            int numberOfRows = 5;
            int numberOfColumns = 10;
            int numberOfCells = numberOfRows * numberOfColumns;
            char[,] playingGrid = new char[numberOfRows, numberOfColumns];

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    playingGrid[i, j] = '-';
                }
            }

            List<int> minedCells = new List<int>();

            while (minedCells.Count < 15)
            {
                Random random = new Random();
                int randomInteger = random.Next(numberOfCells);

                if (!minedCells.Contains(randomInteger))
                {
                    minedCells.Add(randomInteger);
                }
            }

            foreach (int cellNumber in minedCells)
            {
                int col = cellNumber / numberOfColumns;
                int row = cellNumber % numberOfColumns;

                if (row == 0 && cellNumber != 0)
                {
                    col--;
                    row = numberOfColumns;
                }
                else
                {
                    row++;
                }

                playingGrid[col, row - 1] = '*';
            }

            return playingGrid;
        }

        private static void WriteSurroundingBombsInCell(char[,] playingGrid)
        {
            int column = playingGrid.GetLength(0);
            int row = playingGrid.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (playingGrid[i, j] != '*')
                    {
                        int numberOfSurroundingBombs = GetSurroundingBombs(playingGrid, i, j);
                        playingGrid[i, j] = ConvertIntToChar(numberOfSurroundingBombs);
                    }
                }
            }
        }

        private static char ConvertIntToChar(int number)
        {
            return char.Parse(number.ToString());
        }

        private static int GetSurroundingBombs(char[,] playingGrid, int row, int col)
        {
            int numberOfBombs = 0;
            int numberOfRows = playingGrid.GetLength(0);
            int numberOfColumns = playingGrid.GetLength(1);

            if (row - 1 >= 0 && playingGrid[row - 1, col] == '*')
            {
                numberOfBombs++;
            }

            if (row + 1 < numberOfRows && playingGrid[row + 1, col] == '*')
            {
                numberOfBombs++;
            }

            if (col - 1 >= 0 && playingGrid[row, col - 1] == '*')
            {
                numberOfBombs++;
            }

            if (col + 1 < numberOfColumns && playingGrid[row, col + 1] == '*')
            {
                numberOfBombs++;
            }

            if ((row - 1 >= 0) && (col - 1 >= 0) && playingGrid[row - 1, col - 1] == '*')
            {
                numberOfBombs++;
            }

            if ((row - 1 >= 0) && (col + 1 < numberOfColumns) && playingGrid[row - 1, col + 1] == '*')
            {
                numberOfBombs++;
            }

            if ((row + 1 < numberOfRows) && (col - 1 >= 0) && playingGrid[row + 1, col - 1] == '*')
            {
                numberOfBombs++;
            }

            if ((row + 1 < numberOfRows) && (col + 1 < numberOfColumns) && playingGrid[row + 1, col + 1] == '*')
            {
                numberOfBombs++;
            }

            return numberOfBombs;
        }
    }
}
