using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;



class Program
{
    static void Main(string[] args)
    {
        
        var autos = new List<Auto>
        {
            new Auto
            {
                LastName = "Ivanov",
                CarNumber = "AB123CD",
                Brand = "Ford",
                Price = 25000,
                HomeAddress = "Kyiv"
            },
            new Auto
            {
                LastName = "Petrov",
                CarNumber = "XY777ZZ",
                Brand = "Honda",
                Price = 30000,
                HomeAddress = "Lviv"
            },
            new Auto
            {
                LastName = "Sidorov",
                CarNumber = "YZ987AB",
                Brand = "Ford",
                Price = 28000,
                HomeAddress = "Odesa"
            }
        };

        
        File.WriteAllText("Auto.json", JsonConvert.SerializeObject(autos, Formatting.Indented));

        
        string json = File.ReadAllText("Auto.json");
        Console.WriteLine(json);

        
        var loadedAutos = JsonConvert.DeserializeObject<List<Auto>>(json);

        
        int fordOwnersWith7 = loadedAutos.Count(auto => auto.Brand == "Ford" && auto.CarNumber.Contains("7"));

        Console.WriteLine($"Кількість власників машин марки Ford з цифрою 7 в номері: {fordOwnersWith7}");

        
        decimal totalFordPrice = loadedAutos.Where(auto => auto.Brand == "Ford").Sum(auto => auto.Price);

        Console.WriteLine($"Загальна вартість усіх машин марки Ford: {totalFordPrice:C}");
    }
}
