using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorDesignPattern
{
    public class Participant
    {
        public Chatroom Chatroom { get; set; }
        public string Name { get; set; }

        public Participant(string name) {
            this.Name = name;
        }

        public void Send(string to, string message) {
            this.Chatroom.Send(this.Name, to, message);
        }

        public virtual void Receive(string from, string message) {
            Console.WriteLine("{0} to {1}: '{2}'", from, this.Name, message);
        }
    }
}
