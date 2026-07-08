using ConferenceRoomBooking.Application.Commands.ConferenceRoom;
using ConferenceRoomBooking.Application.DTOs.Requests.ConferenceRoom;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceRoomBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceRoomsController : ControllerBase
    {
        //// GET: api/<ConferenceRoomsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ConferenceRoomsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ConferenceRoomsController>
        [HttpPost]
        public async Task<IActionResult> AddConferenceRoom([FromServices] IRequestHendler<AddConferenceRoomCommand> addConferenceRoomCommand, 
            [FromBody] AddConferenceRoomRequest conferenceRoomRequest)
        {
            var conferenceRoomCommand = new AddConferenceRoomCommand
            {
                Name = conferenceRoomRequest.Name,
                Capacity = conferenceRoomRequest.Capacity,
                BasePrice = conferenceRoomRequest.BasePrice
            };

            await addConferenceRoomCommand.HendlerAsync(conferenceRoomCommand);

            return Ok(200);
        }

        // PUT api/<ConferenceRoomsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpsertConferenceRoom([FromServices] IRequestHendler<UpsertConferenceRoomCommand> upsertConferenceRoomCommand, 
            [FromBody] UpsertConferenceRoomRequest upsertConferenceRoomRequest)
        {
            await upsertConferenceRoomCommand.HendlerAsync(new UpsertConferenceRoomCommand
            {
                Id = upsertConferenceRoomRequest.Id,
                Name = upsertConferenceRoomRequest.Name,
                Capacity = upsertConferenceRoomRequest.Capacity,
                BasePrice = upsertConferenceRoomRequest.BasePrice
            });

            return Ok(200);
        }

        //// DELETE api/<ConferenceRoomsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
