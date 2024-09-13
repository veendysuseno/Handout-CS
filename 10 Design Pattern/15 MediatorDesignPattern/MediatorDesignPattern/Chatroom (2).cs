using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorDesignPattern
{
    public class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Participant> Participants { get; set; }

        public Chatroom() {
            this.Participants = new Dictionary<string, Participant>();
        }

        public override void Register(Participant participant) {
            if (!this.Participants.ContainsValue(participant)) {
                this.Participants[participant.Name] = participant;
            }
            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message) {
            Participant participant = this.Participants[to];
            if (participant != null) {
                participant.Receive(from, message);
            }
        }
    }
}
