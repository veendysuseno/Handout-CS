using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Person() {
        }
        public Person(string name, DateTime birthDate) {
            Name = name;
            BirthDate = birthDate;
        }
        public int CalculateAge() {
            var duration = (DateTime.Today - this.BirthDate).Days;
            return duration / 365;
        }
    }
}
