using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection_Statement {
    class Program {
        static void Main(string[] args) {

            #region Basic If

            bool conditionOne = true;
            if (conditionOne == true) {
                Console.WriteLine("Condition one is true");
            }

            Console.WriteLine("Fill condition two:");
            string conditionTwo = Console.ReadLine();
            if (conditionTwo == "correct") {
                Console.WriteLine("Condition two is correct");
            }
            if (conditionTwo.Equals("correct")) {
                Console.WriteLine("Condition two is correct");
            }

            #endregion

            #region Comparison Operator

            int conditionThree = 5;
            int conditionFour = 5;
            int conditionFive = 20;
            double conditionSeven = 5.0;

            //sama dengan
            if (conditionThree == conditionFour) {
                Console.WriteLine("Condition Three and Four are the same");
            }

            //tidak sama dengan
            if (conditionThree != conditionFive) {
                Console.WriteLine("Condition Three and Five are not the same");
            }

            //lebih besar
            if (conditionFive > conditionThree) {
                Console.WriteLine("Condition Five is bigger that Condition Three");
            }

            //lebih besar sama dengan
            if (conditionThree >= conditionFour) {
                Console.WriteLine("Condition Three is bigger than or the same as condition Four");
            }
            if (conditionFive >= conditionThree) {
                Console.WriteLine("Condition Five is bigger than or the same as Condition Three");
            }

            //lebih kecil
            if (conditionFour < conditionFive) {
                Console.WriteLine("Condition Four is smaller than Condition Five");
            }

            //lebih kecil sama dengan
            if (conditionThree <= conditionFour) {
                Console.WriteLine("Condition Three is smaller than or the same as Condition Four");
            }
            if (conditionThree <= conditionFive) {
                Console.WriteLine("Condition Three is smaller than or the same as Condition Five");
            }

            //Atau (Or): salah satu (satu atau lebih) benar maka kondisi terpenuhi
            if (conditionOne == true || conditionThree > conditionFive || conditionThree != conditionFour) {
                Console.WriteLine("Condition Or reached");
            }
            if (conditionThree > conditionFive || conditionThree != conditionFour) {
                Console.WriteLine("Condition Or reached");
            }


            //Dan (And): semua harus benar untuk kondisi terpenuhi
            if (conditionFive > conditionThree && conditionFour < conditionFive && conditionOne == true) {
                Console.WriteLine("Condition And reached");
            }
            if (conditionOne == true && conditionThree > conditionFive && conditionThree != conditionFour) {
                Console.WriteLine("Condition And reached");
            }

            //Membandingkan variable yang berbeda dari tipe data yang berbeda
            if (conditionThree == conditionSeven) {
                Console.WriteLine("Integer and Decimal can be compared");
            }

            #endregion

            #region If and Else

            if (conditionThree == 9) {
                Console.WriteLine("Condition three is 9");
            } else {
                Console.WriteLine("Condition three is not 9. (other than 9)");
            }

            Console.WriteLine("Pilih minuman mu: 1.Coca-cola, 2.Sprite, 3.Fanta, 4.Lemon Tea");
            string caseString = Console.ReadLine();

            if (caseString == "1") {
                Console.WriteLine("Kamu mendapatkan Coca-cola");
            } else if (caseString == "2") {
                Console.WriteLine("Kamu mendapatkan Sprite");
            } else if (caseString == "3") {
                Console.WriteLine("Kamu mendapatkan Fanta");
            } else if (caseString == "4") {
                Console.WriteLine("Kamu mendapatkan Lemon Tea");
            } else {
                Console.WriteLine("Error, kamu harus ketik 1, 2, 3, atau 4.");
            }

            #endregion

            #region Switch case

            Console.WriteLine("Pilih minuman mu: 1.Coca-cola, 2.Sprite, 3.Fanta, 4.Lemon Tea");
            string caseInput = Console.ReadLine();

            switch (caseInput) {
                case "1":
                    Console.WriteLine("Kamu mendapatkan Coca-cola");
                    break;
                case "2":
                    Console.WriteLine("Kamu mendapatkan Sprite");
                    break;
                case "3":
                    Console.WriteLine("Kamu mendapatkan Fanta");
                    break;
                case "4":
                    Console.WriteLine("Kamu mendapatkan Lemon Tea");
                    break;
                default:
                    Console.WriteLine("Error, kamu harus ketik 1, 2, 3, atau 4.");
                    break;
            }

            #endregion

            #region Notasi Pendek

            bool theOutcome = false;

            if (theOutcome) { //Khusus untuk boolean true, kita bisa menulis tanpa comparison sign
                Console.WriteLine("The outcome is true");
            }

            //Kasus untuk yang == false
            if (!theOutcome) {
                Console.WriteLine("The outcome is false");
            }

            if (theOutcome == true)
                Console.WriteLine("The outcome is true");

            string outcomeString = (theOutcome == true) ? "the outcome is true" : "the outcome is false";
            Console.WriteLine(outcomeString);

            #endregion
        }
    }
}
