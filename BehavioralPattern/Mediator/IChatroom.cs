using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mediator
{
    public interface IChatroom
    {
        List<Participant> Participants { get;}
        void AddParticipant(Participant participant);
        void Send(string message, IParticipant sender, IParticipant receiver);
    }
}
