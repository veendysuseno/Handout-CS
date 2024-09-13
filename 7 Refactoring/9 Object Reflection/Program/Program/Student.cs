using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Student : Person
    {
        public string StudentNumber { get; set; }
        public Student() : base() {
        }
        public Student(string name, DateTime birthDate, string studentNumber) : base(name, birthDate) {
            this.StudentNumber = studentNumber;
        }
        public void PrintStudentInfo() {
            Console.WriteLine($"Student number: {this.StudentNumber}, Name: {this.Name}, Age: {this.CalculateAge()}");
        }
    }
}
