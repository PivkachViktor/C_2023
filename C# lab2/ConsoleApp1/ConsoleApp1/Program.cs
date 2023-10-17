using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        private static void TaskA(DataCollections data, string serviceType)
        {
            // Групуємо дані за прізвищем жильця і обчислюємо середню суму оплати для кожного жильця
            var averagePaymentsBySurname = data.Payments
                .Where(p => p.TypeOfService == serviceType)
                .GroupBy(p => p.Surname)
                .Select(group => new
                {
                    Surname = group.Key,
                    AveragePayment = group.Average(p => p.PaidAmount)
                });

            // Виводимо результати в консоль
            Console.WriteLine($"Середня сплата за {serviceType} у поточному місяці:");

            foreach (var item in averagePaymentsBySurname)
            {
                Console.WriteLine($"Житель: {item.Surname}, Середня сума сплати: {item.AveragePayment}");
            }
        }
        private static int GetMonthNumber(string monthName)
        {
            switch (monthName)
            {
                case "Січень": return 1;
                case "Лютий": return 2;
                case "Березень": return 3;
                case "Квітень": return 4;
                case "Травень": return 5;
                case "Червень": return 6;
                case "Липень": return 7;
                case "Серпень": return 8;
                case "Вересень": return 9;
                case "Жовтень": return 10;
                case "Листопад": return 11;
                case "Грудень": return 12;
                default:
                    throw new ArgumentException("Невірний місяць: " + monthName);
            }
        }
        private static void TaskB(DataCollections data)
        {
            // Отримуємо поточний квартал (якщо січень-березень, то це 1-й квартал, квітень-червень - 2-й квартал і т.д.)
            int currentQuarter = (DateTime.Now.Month - 1) / 3 + 1;

            // Групуємо дані за видом послуги і обчислюємо загальну суму нарахованих платежів за останній квартал
            var totalAccruedByService = data.Comservis
                .Where(c => (currentQuarter - 1) * 3 < GetMonthNumber(c.Date) && GetMonthNumber(c.Date) <= currentQuarter * 3)
                .GroupBy(c => c.TypeOfService)
                .Select(group => new
                {
                    ServiceType = group.Key,
                    TotalAccrued = group.Sum(c => c.AmountAccrued)
                });

            // Знаходимо послугу, за яку нараховано найбільшу суму
            var maxAccruedService = totalAccruedByService.OrderByDescending(s => s.TotalAccrued).First();

            // Виводимо результат в консоль
            Console.WriteLine($"За останній квартал найбільша сума нарахована за послугою: {maxAccruedService.ServiceType}");
        }

        private static void TaskC(DataCollections data)
        {
            // Групуємо дані за прізвищем жильця і обчислюємо сумарну заборгованість для кожного жильця
            var totalDebtBySurname = data.Comservis
                .GroupBy(c => c.Surname)
                .Select(group => new
                {
                    Surname = group.Key,
                    TotalDebt = group.Sum(c => c.AmountAccrued) - data.Payments
                        .Where(p => p.Surname == group.Key)
                        .Sum(p => p.PaidAmount)
                })
                .Where(item => item.TotalDebt > 0)
                .OrderByDescending(item => item.TotalDebt);

            // Повертаємо результат як колекцію для подальшого виведення в Main
            foreach (var item in totalDebtBySurname)
            {
                Console.WriteLine($"Житель: {item.Surname}, Заборгованість: {item.TotalDebt}");
            }
        }

        static void Main()
        {
            DataCollections data = new DataCollections();
            InitializeData(data);


            string serviceType = "Електроенергія"; // Заданий вид послуги
            TaskA(data, serviceType);
            Console.WriteLine();
            TaskB(data);
            Console.WriteLine();
            TaskC(data);
        }



        static void InitializeData(DataCollections data)
            {
            data.Comservis = new List<Comservis>
            {
                new Comservis
                {
                    Surname = "Петров",
                    Date = "Січень",
                    TypeOfService = "Електроенергія",
                    AmountAccrued = 1000
                },

                new Comservis
                {
                    Surname = "Іванов",
                    Date = "Липень",
                    TypeOfService = "Газ",
                    AmountAccrued = 900
                },
                new Comservis
                {
                    Surname = "Коваль",
                    Date = "Травень",
                    TypeOfService = "Водопостачання",
                    AmountAccrued = 1500
                },
                new Comservis
                {
                    Surname = "Вогар",
                    Date = "Березень",
                    TypeOfService = "Електроенергія",
                    AmountAccrued = 2000
                },
                new Comservis
                {
                    Surname = "Андрусик",
                    Date = "Жовтень",
                    TypeOfService = "Комуналка",
                    AmountAccrued = 1700
                }

            };

            data.Payments = new List<Payment>
            {
                new Payment
                {
                    Surname = "Петров",
                    TypeOfService = "Електроенергія",
                    PaidAmount = 1000m,
                    PaymentDate = "Січень",
                },
                new Payment
                {
                    Surname = "Іванов",
                    TypeOfService = "Газ",
                    PaidAmount = 800,
                    PaymentDate = "Липень",
                },
                new Payment
                {
                    Surname = "Коваль",
                    TypeOfService = "Водопостачання",
                    PaidAmount = 1000m,
                    PaymentDate = "Травень",
                },
                new Payment
                {
                    Surname = "Вогар",
                    TypeOfService = "Електроенергія",
                    PaidAmount = 3000m,
                    PaymentDate = "Березень",
                },
                new Payment
                {
                    Surname = "Андрусик",
                    TypeOfService = "Комуналка",
                    PaidAmount = 1900m,
                    PaymentDate = "Липень",
                },

            };

        }
    }
}
