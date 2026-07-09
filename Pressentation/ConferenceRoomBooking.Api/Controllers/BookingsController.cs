using ConferenceRoomBooking.Application.Commands.Booking;
using ConferenceRoomBooking.Application.DTOs.Requests.Booking;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceRoomBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        //// GET: api/<BookingsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<BookingsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<BookingsController>
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromServices] IRequestHendler<AddBookingCommand> requestHendler,
            [FromBody] AddBookingRequest addBookingRequest)
        {
            await requestHendler.HendlerAsync(new AddBookingCommand
            {
                ConferenceRoomId = addBookingRequest.ConferenceRoomId,
                StartAt = addBookingRequest.StartAt,
                DurationHours = addBookingRequest.DurationHours,
                ServiceIds = addBookingRequest.ServiceIds
            });
            return Ok(200);
        }

        //// PUT api/<BookingsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BookingsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
