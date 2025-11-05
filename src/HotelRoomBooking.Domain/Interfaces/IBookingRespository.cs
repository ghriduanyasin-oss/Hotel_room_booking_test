using HotelRoomBooking.Domain.Entities;

namespace HotelRoomBooking.Domain.Interfaces;

public interface IBookingRepository
{
    Task<Room?> GetRoomAsync(int roomId, CancellationToken ct = default);
    Task<IEnumerable<Booking>> GetBookingsAsync(CancellationToken ct = default);
    Task AddBookingAsync(Booking booking, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}