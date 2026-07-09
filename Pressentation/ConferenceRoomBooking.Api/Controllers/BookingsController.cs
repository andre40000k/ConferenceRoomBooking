using ConferenceRoomBooking.Application.Commands.Booking;
using ConferenceRoomBooking.Application.DTOs.Requests.Booking;
using ConferenceRoomBooking.Application.DTOs.Responses.Booking;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromServices] IRequestHandler<AddBookingCommand, AddBookingResponse> requestHendler,
            [FromBody] AddBookingRequest addBookingRequest)
        {
            var result = await requestHendler.HandlerAsync(new AddBookingCommand
            {
                ConferenceRoomId = addBookingRequest.ConferenceRoomId,
                StartAt = addBookingRequest.StartAt,
                DurationHours = addBookingRequest.DurationHours,
                ServiceIds = addBookingRequest.ServiceIds
            });

            return Ok(result);
        }
    }
}
