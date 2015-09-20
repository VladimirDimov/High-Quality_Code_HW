namespace Command
{
    using System;
    using System.Text;

    public class PlayField
    {
        private bool[,] board;
        private int currentRow;
        private int currentCol;
        private int size;

        public PlayField(int size)
        {
            board = new bool[size, size];
            currentRow = 0;
            currentCol = 0;
            this.Size = size;
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                this.size = value;
            }
        }

        public void Move(Directions direction)
        {
            this.board[currentRow, currentCol] = false;

            switch (direction)
            {

                case Directions.UP:
                    currentRow = Math.Max(0, currentRow - 1);
                    break;
                case Directions.DOWN:
                    currentRow = Math.Min(this.Size - 1, currentRow + 1);
                    break;
                case Directions.LEFT:
                    currentCol = Math.Max(0, currentCol - 1);
                    break;
                case Directions.RIGHT:
                    currentCol = Math.Min(this.Size - 1, currentCol + 1);
                    break;
                default:
                    break;
            }

            this.board[currentRow, currentCol] = true;
            this.Print();
        }

        public override string ToString()
        {
            var board = this.board;
            var output = new StringBuilder();

            for (int row = 0; row < board.GetLength(0); row++)
            {                
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    output.Append(board[row, col] ? "[*]" : "[ ]");
                }
                output.Append(Environment.NewLine);
            }

            return output.ToString();
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine(this.ToString());
        }
    }
}
