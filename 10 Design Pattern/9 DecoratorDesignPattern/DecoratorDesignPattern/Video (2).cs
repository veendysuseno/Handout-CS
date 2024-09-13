using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDesignPattern
{
    public class Video : LibraryItem
    {
        private string Director { get; set; }
        private string Title { get; set; }
        private int PlayTime { get; set; }

        public Video(string director, string title, int numberOfCopies, int playTime) {
            this.Director = director;
            this.Title = title;
            this.PlayTime = playTime;
            this.NumberOfCopies = numberOfCopies;
        }

        public override void Display() {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", this.Director);
            Console.WriteLine(" Title: {0}", this.Title);
            Console.WriteLine(" # Copies: {0}", this.NumberOfCopies);
            Console.WriteLine(" Playtime: {0}\n", this.PlayTime);
        }
    }
}
