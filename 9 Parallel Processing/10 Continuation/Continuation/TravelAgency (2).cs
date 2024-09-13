using Continuation.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Continuation
{
    public static class TravelAgency
    {
        public static readonly object _locker = new object();
        private static volatile List<Participant> _registeredParticipants = new List<Participant>();

        public static async void PrintProfit() {
            RegisterAllParticipants();
            var sumEarnings = SumEarnings();
            var calculateSumCost = CalculateSumCost();
            var profit = sumEarnings.Result - calculateSumCost.Result;
            Console.WriteLine($"Total Profit: {profit.ToString("C2", CultureInfo.GetCultureInfo("id-ID"))}");
            //Profit harusnya bernilai: 326.635.000
        }

        #region Registeration

        public static void RegisterAllParticipants() {
            Task.WaitAll(
                RegisterParticipant("Andri", 1, new DateTime(1988, 7, 9), new DateTime(2020, 4, 3), City.Jakarta),
                RegisterParticipant("Susi", 1, new DateTime(1989, 11, 12), new DateTime(2020, 4, 3), City.Jakarta),
                RegisterParticipant("Andre", 1, new DateTime(2019, 6, 28), new DateTime(2020, 4, 3), City.Jakarta),
                RegisterParticipant("Arnold", 2, new DateTime(1978, 4, 3), new DateTime(2020, 5, 1), City.Bandung),
                RegisterParticipant("Silvi", 2, new DateTime(1975, 11, 1), new DateTime(2020, 5, 1), City.Bandung),
                RegisterParticipant("Gabby", 2, new DateTime(1998, 4, 15), new DateTime(2020, 5, 1), City.Bandung),
                RegisterParticipant("John", 3, new DateTime(1974, 11, 19), new DateTime(2020, 2, 6), City.Semarang),
                RegisterParticipant("Jessica", 3, new DateTime(1974, 7, 29), new DateTime(2020, 2, 6), City.Semarang),
                RegisterParticipant("Hartono", 3, new DateTime(1995, 9, 14), new DateTime(2020, 2, 6), City.Semarang),
                RegisterParticipant("Julia", 3, new DateTime(2000, 12, 18), new DateTime(2020, 2, 6), City.Semarang),
                RegisterParticipant("Ben", 4, new DateTime(1988, 11, 27), new DateTime(2020, 2, 3), City.Surabaya),
                RegisterParticipant("Robert", 5, new DateTime(1988, 7, 9), new DateTime(2020, 4, 25), City.Jakarta),
                RegisterParticipant("Griska", 5, new DateTime(1988, 7, 9), new DateTime(2020, 4, 25), City.Jakarta),
                RegisterParticipant("Vincent", 6, new DateTime(1989, 1, 10), new DateTime(2020, 4, 13), City.Jakarta),
                RegisterParticipant("Novi", 6, new DateTime(1991, 9, 27), new DateTime(2020, 4, 13), City.Jakarta)
            );
        }

        public static async Task RegisterParticipant(string name, int familyId, DateTime birthDate, DateTime registerDate, City departure) {
            await Task.Run(() => {
                var participant = new Participant {
                    Name = name,
                    FamilyId = familyId,
                    BirthDate = birthDate,
                    RegisterDate = registerDate,
                    DepartureFrom = departure
                };
                lock (_locker) {
                    _registeredParticipants.Add(participant);
                }
            });
        }

        #endregion

        #region Earn

        public static async Task<decimal> SumEarnings() {
            decimal earnings = 0;
            await Task.Run(async() => {
                foreach (var participant in _registeredParticipants) {
                    earnings += await CalculateParticipantCost(participant);
                }
            });
            return earnings;
        }

        public static async Task<decimal> CalculateParticipantCost(Participant participant) {
            decimal cost = 20000000;
            await Task.Run(async () => {
                int age = participant.CalculateAge();
                cost += await AgeAdditionalPrice(age);
                cost += await RegisterDateAdditionalPrice(participant.RegisterDate);
                cost += await DepartureAdditionalPrice(participant.DepartureFrom);
            });
            return cost;
        }

        public static async Task<decimal> AgeAdditionalPrice(int age) {
            decimal price = 0;
            await Task.Run(() => {
                if (age > 30) {
                    price = 5000000;
                } else if (age <= 30 && age >= 5) {
                    price = 2000000;
                } else {
                    price = 500000;
                }
            });
            return price;
        }

        public static async Task<decimal> RegisterDateAdditionalPrice(DateTime registerDate) {
            decimal price = 0;
            await Task.Run(() => {
                DateTime closingDate = new DateTime(2020, 5, 5);
                var duration = closingDate - registerDate;
                if (duration.TotalDays > 14) {
                    price = 500000;
                } else {
                    price = 15000;
                }
            });
            return price;
        }

        public static async Task<decimal> DepartureAdditionalPrice(City departure) {
            decimal price = 0;
            await Task.Run(() => {
                switch (departure) {
                    case City.Jakarta:
                        price = 80000;
                        break;
                    case City.Surabaya:
                        price = 200000;
                        break;
                    case City.Semarang:
                        price = 250000;
                        break;
                    case City.Bandung:
                        price = 100000;
                        break;
                }
            });
            return price;
        }

        #endregion

        #region Cost

        public static async Task<decimal> CalculateSumCost() {
            decimal cost = 0;
            await Task.Run(async () => {
                cost += await ChooseBusAndGetCost();
                cost += await CalculateRoomCost();
                cost += await CalculateTicketCost();
                cost += await CalculateVisitCost();
            });
            return cost;
        }

        public static async Task<decimal> ChooseBusAndGetCost() {
            decimal cost = 0;
            await Task.Run(() => {
                string pathRead = ReturnPath("bus.json");
                var jsonString = new StringBuilder();
                using (StreamReader reader = new StreamReader(pathRead)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        jsonString.Append(line);
                    }
                }
                Bus[] busses = JsonSerializer.Deserialize<Bus[]>(jsonString.ToString());
                int totalParticipants = _registeredParticipants.Count;
                if (totalParticipants >= 30) {
                    cost = busses[0].Cost;
                } else if (totalParticipants < 30 && totalParticipants >= 15) {
                    cost = busses[1].Cost;
                } else {
                    cost = busses[2].Cost;
                }
            });
            return cost;
        }

        public static async Task<decimal> CalculateRoomCost() {
            decimal cost = 0;
            await Task.Run(() => {
                decimal hotelRoomPrice = 1300000;
                List<int> groupFamilyId = new List<int>();
                foreach (var participant in _registeredParticipants) {
                    if (!FindUnregisteredFamilyID(participant.FamilyId, groupFamilyId)) {
                        groupFamilyId.Add(participant.FamilyId);
                    }
                }
                cost = groupFamilyId.Count * hotelRoomPrice;
            });
            return cost;
        }

        public static bool FindUnregisteredFamilyID(int id, List<int> groupFamilyId) {
            bool isFound = false;
            foreach (var familyId in groupFamilyId) {
                if (id == familyId) {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        public static async Task<decimal> CalculateTicketCost() {
            decimal cost = 0;
            await Task.Run(() => {
                decimal planeTicketPrice = 3000000;
                foreach (var participant in _registeredParticipants) {
                    if (participant.CalculateAge() > 5) {
                        cost += planeTicketPrice;
                    } else {
                        cost += (planeTicketPrice / 2);
                    }
                }
            });
            return cost;
        }

        public static async Task<decimal> CalculateVisitCost() {
            decimal cost = 0;
            await Task.Run(() => {
                string pathRead = ReturnPath("itinerary.json");
                var jsonString = new StringBuilder();
                using (StreamReader reader = new StreamReader(pathRead)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        jsonString.Append(line);
                    }
                }
                List<Itinerary> itineraries = JsonSerializer.Deserialize<List<Itinerary>>(jsonString.ToString());
                foreach (var itinerary in itineraries) {
                    cost += itinerary.Cost;
                }
            });
            return cost;
        }

        #endregion

        public static string ReturnPath(string fileName) {
            var path = Path.GetFullPath($"../../../Files/{fileName}");
            return path;
        }
    }
}
