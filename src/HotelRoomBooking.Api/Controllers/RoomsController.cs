using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelRoomBooking.Infrastructure.Data;
using HotelRoomBooking.Domain.Entities;

namespace HotelRoomBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _ctx;
    public RoomsController(AppDbContext ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms() =>
        Ok(await _ctx.Rooms.AsNoTracking().ToListAsync());
}