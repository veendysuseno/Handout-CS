using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Person
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public Person() { 
        }
        public Person(string fullName, DateTime birthDate, string gender) {
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
        }
        public int CalculateAge() {
            var daysDuration = (DateTime.Today - this.BirthDate).Days;
            return daysDuration / 365;
        }
    }
}
