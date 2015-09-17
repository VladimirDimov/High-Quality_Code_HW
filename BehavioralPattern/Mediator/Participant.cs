using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mediator
{
    public class Participant : IParticipant
    {
        private string name;
        private IChatroom chatroom;

        public Participant(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public IChatroom Chatroom
        {
            get
            {
                return this.chatroom;
            }
            set
            {
                this.chatroom = value;
            }
        }

        public void Send(string message, IParticipant receiver)
        {
            this.Chatroom.Send(message, this, receiver);
        }

        public void Alert(string message, IParticipant sender)
        {
            Console.WriteLine(sender.Name + " to " + this.Name + ": " + message);
        }
    }
}
