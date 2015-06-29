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
            bool flag = true;
            const int maks = 35;
            bool flag2 = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawPlayingGrid(playingGrid);
                    flag = false;
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
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (minesPositions[row, column] != '*')
                        {
                            if (minesPositions[row, column] == '-')
                            {
                                tisinahod(playingGrid, minesPositions, row, column);
                                pointsCounter++;
                            }
                            if (maks == pointsCounter)
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
                    string niknejm = Console.ReadLine();
                    Player t = new Player(niknejm, pointsCounter);
                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < t.Points)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    Standings(champions);

                    playingGrid = createPlayingGrid();
                    minesPositions = PlaceMines();
                    pointsCounter = 0;
                    stepOnMine = false;
                    flag = true;
                }
                if (flag2)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawPlayingGrid(minesPositions);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    Player to4kii = new Player(imeee, pointsCounter);
                    champions.Add(to4kii);
                    Standings(champions);
                    playingGrid = createPlayingGrid();
                    minesPositions = PlaceMines();
                    pointsCounter = 0;
                    flag2 = false;
                    flag = true;
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

        private static void tisinahod(char[,] playingGrid,
            char[,] mines, int row, int column)
        {
            char kolkoBombi = getSurroundingBombs(mines, row, column);
            mines[row, column] = kolkoBombi;
            playingGrid[row, column] = kolkoBombi;
        }

        private static void DrawPlayingGrid(char[,] board)
        {
            int RRR = board.GetLength(0);
            int KKK = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < RRR; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < KKK; j++)
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
            char[,] playingGrid = new char[numberOfRows, numberOfColumns];

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    playingGrid[i, j] = '-';
                }
            }

            List<int> r3 = new List<int>();
            while (r3.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!r3.Contains(asfd))
                {
                    r3.Add(asfd);
                }
            }

            foreach (int i2 in r3)
            {
                int col = (i2 / numberOfColumns);
                int row = (i2 % numberOfColumns);
                if (row == 0 && i2 != 0)
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

        private static void smetki(char[,] pole)
        {
            int kol = pole.GetLength(0);
            int red = pole.GetLength(1);

            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < red; j++)
                {
                    if (pole[i, j] != '*')
                    {
                        char kolkoo = getSurroundingBombs(pole, i, j);
                        pole[i, j] = kolkoo;
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
