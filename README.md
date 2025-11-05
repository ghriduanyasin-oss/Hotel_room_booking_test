# Hotel Room Booking API (.NET 8)

A simple RESTful API that lets clients list available rooms, create a booking, and retrieve all bookings.  
Built with ASP.NET Core 8, Entity Framework Core , and Swashbuckle for live documentation.

## How to run

1. Clone the repository  
```bash
git clone https://github.com/ghriduanyasin-oss/Hotel_room_booking_test
cd Hotel_Room_Booking

2. Restore & run
dotnet restore
dotnet run --project src/HotelRoomBooking.Api

3. Open Swagger UI
http://localhost:5000/swagger

4. Test the endpoints
GET  /api/rooms     
POST /api/bookings  
GET  /api/bookings

Sample POST body

{
  "guestName": "Ada Lovelace",
  "roomId": 1,
  "checkInDate": "2025-06-01",
  "checkOutDate": "2025-06-03"
}

5. Design decisions
Clean Architecture folders
– Domain - pure entities & interfaces
– Infrastructure - EF Core DbContext & repositories
– Api - controllers, DTOs, wiring
