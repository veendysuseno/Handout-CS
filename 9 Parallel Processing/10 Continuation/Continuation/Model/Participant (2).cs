using System;
using System.Collections.Generic;
using System.Text;

namespace Continuation.Model
{
    public class Participant
    {
        public string Name { get; set; }
        public int FamilyId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public City DepartureFrom { get; set; }

        public int CalculateAge() {
            var duration = DateTime.Today - this.BirthDate;
            int year = (duration.Days % 365);
            return year;
        }
    }
}
