namespace HotelRoomBooking.Domain.Entities;
public class Room
{
public int Id { get; set; }
public string Name { get; set; } = default!;
public string Type { get; set; } = default!;
public bool IsAvailable { get; set; } = true;
}