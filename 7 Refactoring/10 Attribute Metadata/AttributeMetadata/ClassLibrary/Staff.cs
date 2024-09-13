using AttributeMetadata.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeMetadata.ClassLibrary
{
    [Restriction("Management", 2)]
    public class Staff : IEmployee
    {
        /*
         * Lain dengan Restriction, Validation Attribute dikhususkan untuk property.
         * Restriction attribute tidak memiliki constructor, sehingga setiap property di assign terpisah
         */
        [Validation(Nullable = false, CharLength = 50)]
        public string Name { get; set; }

        [Number(Minimum = 0, Maximum = 999999999)]
        public decimal Salary { get; set; }

        [Validation(Nullable = true, CharLength = 20)]
        public string Department { get; set; }
    }
}
