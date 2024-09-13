using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDesignPattern
{
    public class Book : LibraryItem
    {
        public string Author { get; set; }
        public string Title { get; set; }

        public Book(string author, string title, int numberOfCopies) {
            this.Author = author;
            this.Title = title;
            this.NumberOfCopies = numberOfCopies;
        }

        public override void Display() {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", this.Author);
            Console.WriteLine(" Title: {0}", this.Title);
            Console.WriteLine(" # Copies: {0}", this.NumberOfCopies);
        }
    }
}
