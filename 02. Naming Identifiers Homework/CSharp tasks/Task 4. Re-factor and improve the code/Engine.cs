namespace Mines
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {


        static void Main(string[] аргументи)
        {        
            string command = string.Empty;
            char[,] playingGrid = createPlayingGrid();
            char[,] minesPositions = PlaceMines();
            int pointsCounter = 0;
            bool stepOnMine = false;
            List<Player> champions = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool gameStarted = true;
            const int reachedPoints = 35;
            bool flag2 = false;

            do
            {
                if (gameStarted)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawPlayingGrid(playingGrid);
                    gameStarted = false;
                }
                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= playingGrid.GetLength(0) && column <= playingGrid.GetLength(1))
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
                        playingGrid = createPlayingGrid();
                        minesPositions = PlaceMines();
                        DrawPlayingGrid(playingGrid);
                        stepOnMine = false;
                        gameStarted = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (minesPositions[row, column] != '*')
                        {
                            if (minesPositions[row, column] == '-')
                            {
                                OpenCell(playingGrid, minesPositions, row, column);
                                pointsCounter++;
                            }
                            if (reachedPoints == pointsCounter)
                            {
                                flag2 = true;
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
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }
                if (stepOnMine)
                {
                    DrawPlayingGrid(minesPositions);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", pointsCounter);
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

                    playingGrid = createPlayingGrid();
                    minesPositions = PlaceMines();
                    pointsCounter = 0;
                    stepOnMine = false;
                    gameStarted = true;
                }
                if (flag2)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawPlayingGrid(minesPositions);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Player points = new Player(name, pointsCounter);
                    champions.Add(points);
                    Standings(champions);
                    playingGrid = createPlayingGrid();
                    minesPositions = PlaceMines();
                    pointsCounter = 0;
                    flag2 = false;
                    gameStarted = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Standings(List<Player> points)
        {
            Console.WriteLine("\nTo4KI:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void OpenCell(char[,] playingGrid,
            char[,] mines, int row, int column)
        {
            char numberOfMines = getSurroundingBombs(mines, row, column);
            mines[row, column] = numberOfMines;
            playingGrid[row, column] = numberOfMines;
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

        private static char[,] createPlayingGrid()
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
                int col = (cellNumber / numberOfColumns);
                int row = (cellNumber % numberOfColumns);
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

        private static void smetki(char[,] playingGrid)
        {
            int column = playingGrid.GetLength(0);
            int row = playingGrid.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (playingGrid[i, j] != '*')
                    {
                        char kolkoo = getSurroundingBombs(playingGrid, i, j);
                        playingGrid[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char getSurroundingBombs(char[,] playingGrid, int row, int col)
        {
            int numberOfBombs = 0;
            int numberOfRows = playingGrid.GetLength(0);
            int numberOfColumns = playingGrid.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playingGrid[row - 1, col] == '*')
                {
                    numberOfBombs++;
                }
            }
            if (row + 1 < numberOfRows)
            {
                if (playingGrid[row + 1, col] == '*')
                {
                    numberOfBombs++;
                }
            }
            if (col - 1 >= 0)
            {
                if (playingGrid[row, col - 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            if (col + 1 < numberOfColumns)
            {
                if (playingGrid[row, col + 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (playingGrid[row - 1, col - 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < numberOfColumns))
            {
                if (playingGrid[row - 1, col + 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            if ((row + 1 < numberOfRows) && (col - 1 >= 0))
            {
                if (playingGrid[row + 1, col - 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            if ((row + 1 < numberOfRows) && (col + 1 < numberOfColumns))
            {
                if (playingGrid[row + 1, col + 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            return char.Parse(numberOfBombs.ToString());
        }
    }
}
