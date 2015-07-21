// Description: http://bgcoder.com/Contests/Practice/DownloadResource/962
namespace RefactoringTaskThree
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        private static void Main()
        {
            int numberOfRows;
            int numberOfCols;
            int numberOfMoves;

            if (!int.TryParse(Console.ReadLine(), out numberOfRows))
            {
                throw new ArgumentException("Invalid number of rows input.");
            }

            if (!int.TryParse(Console.ReadLine(), out numberOfCols))
            {
                throw new ArgumentException("Invalid number of columns input.");
            }

            if (!int.TryParse(Console.ReadLine(), out numberOfMoves))
            {
                throw new ArgumentException("Invalid number of moves input.");
            }

            BigInteger[,] matrix = CreateMatrix(numberOfRows, numberOfCols);

            var readVisitedCells = Console.ReadLine().Split(' ');

            if (readVisitedCells == null || readVisitedCells.Length == 0)
            {
                throw new ArgumentException("Visisted cells cannot be null or empty.");
            }

            var visitedCells = new int[readVisitedCells.Length];

            for (int i = 0; i < readVisitedCells.Length; i++)
            {
                if (!int.TryParse(readVisitedCells[i], out visitedCells[i]))
                {
                    throw new ArgumentException("Invalid cell coefficient integer value.");
                }

                var numberOfCells = matrix.GetLength(0) * matrix.GetLength(1);
                if (visitedCells[i] < 0 || numberOfCells - 1 < visitedCells[i])
                {
                    throw new ArgumentException("Visisted cells coefficients must be between 0 and number of cells - 1");
                }
            }

            Console.WriteLine(CalculateSum(visitedCells, matrix));
        }

        private static BigInteger[,] CreateMatrix(int numberOfRows, int numberOfCols)
        {
            if (numberOfRows <= 0)
            {
                throw new ArgumentException("Number of columns must be larger than 0.");
            }

            if (numberOfCols <= 0)
            {
                throw new ArgumentException("Number of rows must be larger than 0.");
            }

            var matrix = new BigInteger[numberOfRows, numberOfCols];

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfCols; col++)
                {
                    matrix[row, col] = (BigInteger)(Math.Pow(2, numberOfRows - row - 1) * Math.Pow(2, col));
                }
            }

            return matrix;
        }

        private static BigInteger CalculateSum(int[] visitedCells, BigInteger[,] matrix)
        {
            if (visitedCells == null || visitedCells.Length == 0)
            {
                throw new ArgumentException("Visited cells collection cannot be null or empty.");
            }

            if (matrix == null || matrix.GetLength(0) == 0)
            {
                throw new ArgumentException("Matrix cannot be null or empty.");
            }

            int numberOfRows = matrix.GetLength(0);
            int numberOfCols = matrix.GetLength(1);
            int maxSize = Math.Max(numberOfRows, numberOfCols);
            BigInteger sum = 0;
            int curRow = numberOfRows - 1;
            int curCol = 0;
            foreach (var cell in visitedCells)
            {
                int targetRow = cell / maxSize;
                int targetCol = cell % maxSize;
                sum += GetStepSum(curRow, curCol, targetRow, targetCol, matrix);
                curRow = targetRow;
                curCol = targetCol;
            }

            return sum + matrix[curRow, curCol];
        }

        private static BigInteger GetStepSum(int curRow, int curCol, int targetRow, int targetCol, BigInteger[,] matrix)
        {
            if (curRow < 0 || matrix.GetLength(0) < curRow)
            {
                throw new ArgumentException("Current row is outside the matrix boundries");
            }

            if (curCol < 0 || matrix.GetLength(1) < curCol)
            {
                throw new ArgumentException("Current col is outside the matrix boundries");
            }

            if (targetRow < 0 || matrix.GetLength(0) < targetRow)
            {
                throw new ArgumentException("Target row is outside the matrix boundries");
            }

            if (targetCol < 0 || matrix.GetLength(1) < targetCol)
            {
                throw new ArgumentException("Target col is outside the matrix boundries");
            }

            int rowIncrement = GetIncrement(curRow, targetRow);
            int colIncrement = GetIncrement(curCol, targetCol);
            BigInteger sum = 0;

            while (curCol != targetCol)
            {
                sum += matrix[curRow, curCol];
                matrix[curRow, curCol] = 0;
                curCol += colIncrement;
            }

            while (curRow != targetRow)
            {
                sum += matrix[curRow, curCol];
                matrix[curRow, curCol] = 0;
                curRow += rowIncrement;
            }

            return sum;
        }

        private static int GetIncrement(int curValue, int targetValue)
        {
            if (curValue < targetValue)
            {
                return 1;
            }
            else if (curValue > targetValue)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
