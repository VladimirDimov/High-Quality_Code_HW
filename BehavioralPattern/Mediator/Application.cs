using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Application
    {
        static void Main()
        {
            // Set the chatroom with the participants
            var room = new Chatroom();
            var pesho = new Participant("Pesho");
            var gosho = new Participant("Gosho");
            room.AddParticipant(pesho);
            room.AddParticipant(gosho);

            //Test the chatroom
            pesho.Send("Hi gosho! how are you?", gosho);
            gosho.Send("Hi Pesho! I'm doing great!", pesho);
        }
    }
}
