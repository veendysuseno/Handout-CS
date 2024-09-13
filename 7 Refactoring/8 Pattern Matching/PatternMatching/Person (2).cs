using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching {
    public class Person {
        public string Name { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

        public Person() {

        }

        public Person(string name, char gender, DateTime dateOfBirth, string placeOfBirth) {
            this.Name = name;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.PlaceOfBirth = placeOfBirth;
        }
    }
}
