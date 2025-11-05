namespace HotelRoomBooking.Api.Dtos;

public class BookingResponseDto
{
    public int Id { get; set; }
    public string GuestName { get; set; } = default!;
    public int RoomId { get; set; }
    public string RoomName { get; set; } = default!;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}