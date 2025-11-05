namespace HotelRoomBooking.Api.Dtos;

public class BookingRequestDto
{
    public string GuestName { get; set; } = default!;
    public int RoomId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}