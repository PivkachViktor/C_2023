public class Program
{
    static void Main()
    {
        
        Hotel hotel = new Hotel
        {
            HotelRooms = new List<HotelRoom>
            {
                new HotelRoom { RoomNumber = 111, Floor = 1, Capacity = 4, DailyRate = 100 },
                new HotelRoom { RoomNumber = 112, Floor = 1, Capacity = 3, DailyRate = 120 },
                new HotelRoom { RoomNumber = 113, Floor = 2, Capacity = 2, DailyRate = 90 },
                new HotelRoom { RoomNumber = 114, Floor = 2, Capacity = 1, DailyRate = 130 },
                new HotelRoom { RoomNumber = 114, Floor = 3, Capacity = 1, DailyRate = 130 },
            },
            Tenants = new List<Tenant>
            {
                new Tenant { LastName = "Smith", CheckInDate = new DateTime(2023, 1, 15), RoomNumber = 111, CheckOutDate = new DateTime(2023, 1, 20) },
                new Tenant { LastName = "Johnson", CheckInDate = new DateTime(2023, 2, 10), RoomNumber = 112, CheckOutDate = new DateTime(2023, 2, 20) },
                new Tenant { LastName = "Williams", CheckInDate = new DateTime(2023, 3, 5), RoomNumber = 113, CheckOutDate = new DateTime(2023, 3, 10) },
                new Tenant { LastName = "Brown", CheckInDate = new DateTime(2023, 4, 8), RoomNumber = 114, CheckOutDate = new DateTime(2023, 4, 15) },
                new Tenant { LastName = "Brown", CheckInDate = new DateTime(2023, 4, 8), RoomNumber = 114, CheckOutDate = new DateTime(2023, 4, 15) },
            }
        };

        int roomNumberToCheck = 114; 

        double averageStayDuration = hotel.GetAverageStayDurationInRoomLastYear(roomNumberToCheck);

        Console.WriteLine($"Середня тривалість проживання у кімнаті {roomNumberToCheck}: {averageStayDuration} днів");

        
        var floors = hotel.GetFloorsWithMinRooms();

        Console.WriteLine("Поверхи з найменшою кількістю кімнат:");
        foreach (var floor in floors)
        {
            Console.WriteLine($"Поверх {floor}");
        }

        
        string xmlFileName = "HotelRooms.xml";
        hotel.SaveHotelRoomsToXml(xmlFileName);

        Console.WriteLine($"Дані про кімнати готелю збережено у файлі {xmlFileName}");

    }
}
