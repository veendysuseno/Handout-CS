using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*
     * IPerson merupakan interface manusia, dimana setiap property dan methodnya pasti dimiliki setiap manusia.
     */
    public interface IPerson {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Gender { get; set; }
        DateTime BirthDate { get; set; }
        string BirthPlace { get; set; }
        string IDCardNumber { get; set; }
        string Citizenship { get; set; }
        string MaritalStatus { get; set; }

        void PrintBiodata();
        void PrintPersonIdentity();
        int CalculateAge();
    }
}
