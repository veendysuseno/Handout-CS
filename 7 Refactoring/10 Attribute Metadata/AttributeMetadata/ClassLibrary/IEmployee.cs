using AttributeMetadata.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeMetadata.ClassLibrary
{
    /*
     * Attribute Restriction hanya bisa digunakan oleh Interface atau Class, mencoba menggunakannya di property atau method akan menghasilkan error.
     * Attribute Restriction juga memiliki constructor yang harus di instantiate setiap propertynya.
     * 
     * Note: Seluruh pemakaian Attribute tidak perlu menuliskan kata "Attribute" lagi.
     */
    [Restriction("Core", 1)]
    public interface IEmployee
    {
        string Name { get; set; }
        decimal Salary { get; set; }
    }
}
