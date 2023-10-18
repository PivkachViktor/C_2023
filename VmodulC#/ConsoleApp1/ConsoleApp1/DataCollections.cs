using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

public class Hotel
{
    public List<HotelRoom> HotelRooms { get; set; }
    public List<Tenant> Tenants { get; set; }

    public double GetAverageStayDurationInRoomLastYear(int roomNumber)
    {
        DateTime lastYear = DateTime.Now.AddYears(-1);

        var tenantsInRoomLastYear = Tenants
            .Where(tenant => tenant.RoomNumber == roomNumber && tenant.CheckInDate >= lastYear);

        if (tenantsInRoomLastYear.Any())
        {
            double totalStayDuration = tenantsInRoomLastYear
                .Sum(tenant => (tenant.CheckOutDate - tenant.CheckInDate).TotalDays);

            return totalStayDuration / tenantsInRoomLastYear.Count();
        }
        else
        {
            return 0; // Якщо немає жильців в цій кімнаті за останній рік
        }
    }

    public IEnumerable<int> GetFloorsWithMinRooms()
    {
        var minRoomCount = HotelRooms
            .GroupBy(room => room.Floor)
            .Min(group => group.Count());

        var floorsWithMinRooms = HotelRooms
            .Where(room => room.Floor == HotelRooms
                .GroupBy(r => r.Floor)
                .Where(g => g.Count() == minRoomCount)
                .Select(g => g.Key)
                .First())
            .Select(room => room.Floor)
            .Distinct();

        return floorsWithMinRooms;
    }

    public void SaveHotelRoomsToXml(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<HotelRoom>));

        using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
        {
            serializer.Serialize(fileStream, HotelRooms);
        }
    }

}

public struct HotelRoom
{
    public int RoomNumber { get; set; }
    public int Floor { get; set; }
    public int Capacity { get; set; }
    public decimal DailyRate { get; set; }
}

public struct Tenant
{
    public string LastName { get; set; }
    public DateTime CheckInDate { get; set; }
    public int RoomNumber { get; set; }
    public DateTime CheckOutDate { get; set; }
}
