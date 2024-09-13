using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBodiedMembers {
    public class Person {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private int _totalChild;

        public Person(string firstName, string lastName, DateTime dateOfBirth, int totalChild) {
            this._firstName = firstName;
            this._lastName = lastName;
            this._dateOfBirth = dateOfBirth;
            this._totalChild = totalChild;
        }

        /*
         * Expression Bodied Member adalah tata cara penulisan method, dimana method tersebut hanya terdiri dari single statement atau single expression.
         * Penulisannya seperti menggunakan penulisan pada lambda expression.
         */
        public override string ToString() => $"nama lengkap: {_firstName} {_lastName}, umur: {_dateOfBirth.ToLongDateString()}, jumlah anak {_totalChild}";
        public void DisplayName() => Console.WriteLine(ToString());
        public int CalculateAge() => DateTime.Today.Year - this._dateOfBirth.Year;
           
    }
}
