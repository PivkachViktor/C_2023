using System;
using System.Xml;

class Program
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("Auto.xml");

        XmlNodeList autoNodes = xmlDoc.SelectNodes("/Autos/Auto");
        Console.WriteLine("Список автомобілів:");

        foreach (XmlNode autoNode in autoNodes)
        {
            Console.WriteLine("Прізвище: " + autoNode.SelectSingleNode("LastName").InnerText);
            Console.WriteLine("Номер машини: " + autoNode.SelectSingleNode("CarNumber").InnerText);
            Console.WriteLine("Марка: " + autoNode.SelectSingleNode("Brand").InnerText);
            Console.WriteLine("Ціна: " + autoNode.SelectSingleNode("Price").InnerText);
            Console.WriteLine("Домашня адреса: " + autoNode.SelectSingleNode("Address").InnerText);
            Console.WriteLine();
        }

        int count = 0;
        foreach (XmlNode autoNode in autoNodes)
        {
            string brand = autoNode.SelectSingleNode("Brand").InnerText;
            string carNumber = autoNode.SelectSingleNode("CarNumber").InnerText;

            if (brand == "Ford" && carNumber.Contains("7"))
            {
                count++;
            }
        }
        Console.WriteLine($"Кількість власників машини марки Ford з цифрою 7: {count}");

        decimal totalPrice = 0;
        foreach (XmlNode autoNode in autoNodes)
        {
            string brand = autoNode.SelectSingleNode("Brand").InnerText;
            decimal price = Convert.ToDecimal(autoNode.SelectSingleNode("Price").InnerText);

            if (brand == "Ford")
            {
                totalPrice += price;
            }
        }
        Console.WriteLine($"Загальна вартість машини марки Ford: {totalPrice}");
    }
}
