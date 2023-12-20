using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\MegaNotik\Desktop\C# Mkr2\ConsoleApp1\ConsoleApp1\Auto.mdf"";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var autoRep = new AutoRepository(connection);

                while (true)
                {
                    Console.WriteLine("Таблиця Автомобілів. Введіть операцію, яку ви хочете виконати:");
                    Console.WriteLine("a - вивести всі дані про авто;");
                    Console.WriteLine("b - визначити кількість власників автомобілів марки X, у номері яких є принаймні одна цифра 7;");
                    Console.WriteLine("c - обчислити загальну вартість усіх авто марки X;");
                    Console.WriteLine(":");

                    string request = Console.ReadLine();
                    List<Auto> autos = new List<Auto>();

                    if (request.ToLower() == "a")
                    {
                        autos = autoRep.GetAllAuto();
                        foreach (var auto in autos)
                        {
                            Console.WriteLine($"Id: {auto.Id}, LastName: {auto.LastName}, CarNumber: {auto.CarNumber}, Brand: {auto.Brand}, Price: {auto.Price}, HomeAddress: {auto.HomeAddress}");
                        }
                    }
                    else if (request.ToLower() == "b")
                    {
                        Console.Write("Введіть марку авто: ");
                        string brand = Console.ReadLine();
                        int count = autoRep.CountOwnersOfCarsWithDigitSevenInNumber(brand);
                        Console.WriteLine($"Кількість власників авто марки {brand}, у номері яких є принаймні одна цифра 7: {count}");
                    }
                    else if (request.ToLower() == "c")
                    {
                        Console.Write("Введіть марку авто: ");
                        string brand = Console.ReadLine();
                        decimal totalPrice = autoRep.CalculateTotalPriceOfBrandCars(brand);
                        Console.WriteLine($"Загальна вартість усіх авто марки {brand}: {totalPrice}");
                    }

                    Console.ReadLine();
                }
            }
        }
    }
}
