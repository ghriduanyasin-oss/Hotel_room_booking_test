using HotelRoomBooking.Domain.Entities;
using HotelRoomBooking.Domain.Interfaces;
using HotelRoomBooking.Infrastructure.Data;
using HotelRoomBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ──── services ----------------------------------------------------------
builder.Services.AddControllers();                       // API controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("HotelDb"));
builder.Services.AddScoped<IBookingRepository, BookingRepository>();    

var app = builder.Build();

// ──── seed data ---------------------------------------------------------
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!ctx.Rooms.Any())
    {
        ctx.Rooms.AddRange(
            new Room { Name = "101", Type = "Single" },
            new Room { Name = "102", Type = "Double" },
            new Room { Name = "201", Type = "Suite" });
        ctx.SaveChanges();
    }
}

// ──── pipeline ----------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();   // wires up Rooms/Bookings controllers
app.Run();