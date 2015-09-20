using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command
{
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
}
