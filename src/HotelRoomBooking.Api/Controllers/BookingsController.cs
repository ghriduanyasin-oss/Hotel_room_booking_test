using Microsoft.AspNetCore.Mvc;
using HotelRoomBooking.Api.Dtos;
using HotelRoomBooking.Domain.Interfaces;
using HotelRoomBooking.Domain.Entities;

namespace HotelRoomBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingRepository _repo;
    public BookingsController(IBookingRepository repo) => _repo = repo;

    // GET api/bookings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookingResponseDto>>> GetBookings()
    {
        var bookings = await _repo.GetBookingsAsync();
        return Ok(bookings.Select(b => new BookingResponseDto
        {
            Id = b.Id,
            GuestName = b.GuestName,
            RoomId = b.RoomId,
            RoomName = b.Room.Name,
            CheckInDate = b.CheckInDate,
            CheckOutDate = b.CheckOutDate
        }));
    }

    // POST api/bookings
    [HttpPost]
    public async Task<ActionResult<BookingResponseDto>> CreateBooking(BookingRequestDto dto)
    {
        // 1. room exists?
        var room = await _repo.GetRoomAsync(dto.RoomId);
        if (room is null) return NotFound("Room not found");

        // 2. room available?
        if (!room.IsAvailable) return BadRequest("Room is already booked");

        // 3. create booking
        var booking = new Booking
        {
            GuestName = dto.GuestName,
            RoomId = dto.RoomId,
            CheckInDate = dto.CheckInDate,
            CheckOutDate = dto.CheckOutDate
        };

        // 4. mark room occupied
        room.IsAvailable = false;

        await _repo.AddBookingAsync(booking);
        await _repo.SaveChangesAsync();

        // 5. return response
        return CreatedAtAction(nameof(GetBookings),
            new { id = booking.Id },
            new BookingResponseDto
            {
                Id = booking.Id,
                GuestName = booking.GuestName,
                RoomId = booking.RoomId,
                RoomName = room.Name,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate
            });
    }
}