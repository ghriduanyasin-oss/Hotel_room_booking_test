namespace HotelRoomBooking.Domain.Entities;
public class Booking
{
public int Id { get; set; }
public string GuestName { get; set; } = default!;
public int RoomId { get; set; }
public Room Room { get; set; } = default!;
public DateTime CheckInDate { get; set; }
public DateTime CheckOutDate { get; set; }
}