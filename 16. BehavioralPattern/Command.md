#Command
В основата на шаблона седи обектът команда, който капсулира извикването на даден метод. Целта е да се отдели логиката, която предизвиква дадено действие, от логиката по неговото изпълнение.

## Участници

**Команда (Command):**
Това е базовият интерфейс на командата.

**Конкретна команда (Concrete Command):**
Това са различните имплементации на Command.

**Получател (Receiver):**
Това е класът, който знае как да изпълни конкретните операции, стоящи зад дадена команда.

**Инициатор (Invoker):**
Инициаторът предизвиква изпълнението на командата, когато това е необходимо.

**Клиент (Client):**
Това е класът, отговорен за създаването на различните конкретни команди, като им подава получател и друга, необходима им информация. Този клас често е отговорен и за подаването на тези команди на класа инициатор (Invoker).

##Принципна диаграма
![Принципна диаграма](images/command.gif)

##Пример

**Command:**

	public interface ICommand
    {
        void Execute();
        void Unexecute();
    }

**Concrete command:**

	public class PlayFieldCommand : ICommand
    {
        private Directions direction;
        private Command.PlayField playField;

        public PlayFieldCommand(PlayField playField, Directions direction)
        {
            this.PlayField = playField;
            this.Direction = direction;
        }

        public Directions Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                this.direction = value;
            }
        }

        public PlayField PlayField
        {
            get
            {
                return this.playField;
            }

            private set
            {
                this.playField = value;
            }
        }

        public void Execute()
        {
            this.playField.Move(this.direction);
        }

        public void Unexecute()
        {
            this.playField.Move(GetOpposite(this.direction));
        }

        private Directions GetOpposite(Directions direction)
        {
            switch (direction)
            {
                case Directions.UP:
                    return Directions.DOWN;
                case Directions.DOWN:
                    return Directions.UP;
                case Directions.LEFT:
                    return Directions.RIGHT;
                case Directions.RIGHT:
                    return Directions.LEFT;
                default:
                    throw new ArgumentException("Invalid direction");
            }
        }
    }

**Receiver:**
	
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

**Invoker:**

	public interface IUser
    {
        PlayField Field { get; }
        IList<PlayFieldCommand> Commands { get; }
        void Move(Directions direction);
        void Undo();
        void Redo();
    }

	public class User : IUser
    {
        private PlayField field;
        private IList<PlayFieldCommand> commands;
        private int currentCommandNumber = 0;

        public User(PlayField playField)
        {
            this.commands = new List<PlayFieldCommand>();
            this.Field = playField;
        }

        public PlayField Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                this.field = value;
            }
        }

        public IList<PlayFieldCommand> Commands
        {
            get
            {
                return this.commands;
            }
        }

        public void Undo()
        {
            if (currentCommandNumber > 0)
            {
                currentCommandNumber--;
            }

            var lastCommand = this.commands[currentCommandNumber];
            lastCommand.Unexecute();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }


        public void Move(Directions direction)
        {
            var newCommand = new PlayFieldCommand(this.field, direction);
            newCommand.Execute();            
            this.commands.Add(newCommand);
            currentCommandNumber++;
        }
    }

**Client:**

	class Application
    {
        static void Main()
        {
            var user = new User(new PlayField(10));

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        user.Move(Directions.UP);
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        user.Move(Directions.DOWN);
                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        user.Move(Directions.LEFT);
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        user.Move(Directions.RIGHT);
                    }
                    else if (keyInfo.Key == ConsoleKey.U)
                    {
                        user.Undo();
                    }
                }
            }
        }
    }

**Enumerations**

	public enum Directions
    {
        UP, DOWN, LEFT, RIGHT
    }