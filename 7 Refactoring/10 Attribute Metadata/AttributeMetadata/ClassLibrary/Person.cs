using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeMetadata.ClassLibrary
{
    /*
     * Value dari object person akan ditampilkan lewat format di dalam format DebuggerDisplay pada saat di debug.
     */
    [DebuggerDisplay("Namanya: {Name}, Jenis Kelaminnya: {Gender}, Kota Lahir: {BirthPlace}")]
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }

        public Person(string name, string gender, string birthPlace) {
            this.Name = name;
            this.Gender = gender;
            this.BirthPlace = birthPlace;
        }
    }
}
