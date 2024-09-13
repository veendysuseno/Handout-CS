using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialType {
    class Program {
        static void Main(string[] args) {

            /*
             * Partial Class atau Partial Struct digunakan saat seseorang bekerja di project besar atau 
             * bekerja pada project environment dimana menggunakan generated code, dan ada kebutuhan untuk membuat tambahan pada exisiting class atau struct.
             * 
             * Persyaratan dari partial class:
             * 1. Harus berada di dalam namespace/ assembly yang sama, kalau tidak nanti access modifiernya akan paradox, terutama untuk protected.
             * 2. Kedua kelas harus memiliki access modifier yang samadan juga tipe class yang sama, baik based, abstract, sealed, dan lain-lain.
             */

            /*Property dari kedua partial class bisa digabungkan menjadi satu class*/
            Employee sandra = new Employee();
            sandra.FirstName = "Sandra";
            sandra.LastName = "Bullock";
            sandra.BirthDate = new DateTime(1988, 11, 27);
            sandra.BirthCity = "Jakarta";
            sandra.BirthCountry = "Indonesia";
            sandra.Salary = 8000000m;

            sandra.PrintBirthDate();
            sandra.PrintBirthPlace();
            sandra.PrintName();
            sandra.PrintSalary();

            sandra.PrintBonus(0.15m);

            /*
             * Partial Struct hampir mirip seperti partial class, hanya saja property member dari partial struct akan mengakibatkan warning message apabila dipisah-pisahkan dari 
             * satu partial ke partial lainnya.
             */
            Assignment programmer = new Assignment();
            programmer.JobTitle = "Web Programmer";
            programmer.Department = "IT Department";
            programmer.Superior = "Michael Shannon";
            programmer.JobDescription = new List<string>(){
                "Membuat aplikasi berbasis web",
                "Membuat arsitektur dan dokumentasi aplikasi"
            };

            programmer.PrintAssignmentInformation();


        }
    }
}
