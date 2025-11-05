using HotelRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomBooking.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Booking> Bookings => Set<Booking>();
}