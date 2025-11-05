using HotelRoomBooking.Domain.Entities;
using HotelRoomBooking.Domain.Interfaces;
using HotelRoomBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomBooking.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _ctx;
    public BookingRepository(AppDbContext ctx) => _ctx = ctx;

    public Task<Room?> GetRoomAsync(int roomId, CancellationToken ct = default)
        => _ctx.Rooms.FirstOrDefaultAsync(r => r.Id == roomId, ct);

    public Task<IEnumerable<Booking>> GetBookingsAsync(CancellationToken ct = default)
        => Task.FromResult<IEnumerable<Booking>>(_ctx.Bookings.Include(b => b.Room).AsNoTracking());

    public Task AddBookingAsync(Booking booking, CancellationToken ct = default)
    {
        _ctx.Bookings.Add(booking);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync(CancellationToken ct = default)
        => _ctx.SaveChangesAsync(ct);
}