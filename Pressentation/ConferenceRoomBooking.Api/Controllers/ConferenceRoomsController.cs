using ConferenceRoomBooking.Application.Commands.ConferenceRoom;
using ConferenceRoomBooking.Application.DTOs.Requests.ConferenceRoom;
using ConferenceRoomBooking.Application.DTOs.Responses.ConferenceRoom;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Application.Queries.ConferenceRoom;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailableConferenceRoomRespons>>> GetAvailableRooms([FromServices] IRequestHendler<GetAvailableConferenceRoomsQuery, IEnumerable<AvailableConferenceRoomRespons>> requestHendler,
            [FromBody] AvailableConferenceRoomRequest availableConferenceRoom)
        {
            var query = new GetAvailableConferenceRoomsQuery
            {
                StartDateTime = availableConferenceRoom.StartAt,
                DurationHours = availableConferenceRoom.DurationHours,
                Capacity = availableConferenceRoom.Capacity
            };

            return Ok(await requestHendler.HendlerAsync(query));
        }

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
        [HttpPut]
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

        // DELETE api/<ConferenceRoomsController>/5
        [HttpDelete]
        public async Task<IActionResult> DeleteConferenceRoom([FromServices] IRequestHendler<DeleteConferenceRoomCommand> deleteConferenceRoomCommand,
            Guid idRequest)
        {
            await deleteConferenceRoomCommand.HendlerAsync(new DeleteConferenceRoomCommand
            {
                Id = idRequest
            });
            return Ok(200);
        }
    }
}
