namespace Mediator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Mediator
    /// </summary>
    public class Chatroom : IChatroom
    {
        private List<Participant> participants;

        public Chatroom()
        {
            this.participants = new List<Participant>();
        }

        public List<Participant> Participants
        {
            get
            {
                return this.participants;
            }
        }

        public void AddParticipant(Participant participant)
        {
            this.participants.Add(participant);
            participant.Chatroom = this;
        }

        public void Send(string message, IParticipant sender, IParticipant receiver)
        {
            receiver.Alert(message, sender);
        }
    }
}
