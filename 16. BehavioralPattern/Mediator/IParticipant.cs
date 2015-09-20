using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mediator
{
    public interface IParticipant
    {
        string Name { get; }
        IChatroom Chatroom { get; set; }
        void Send(string message, IParticipant receiver);
        void Alert(string message, IParticipant sender);
    }
}
