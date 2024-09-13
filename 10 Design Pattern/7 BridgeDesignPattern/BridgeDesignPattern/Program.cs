using System;

namespace BridgeDesignPattern
{
    class Program
    {
        static void Main(string[] args) {
            Customers customers = new Customers("Chicago");
            customers.DataObject = new CustomersData();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Add("Henry Velasquez");
            customers.ShowAll();
        }
    }
}
