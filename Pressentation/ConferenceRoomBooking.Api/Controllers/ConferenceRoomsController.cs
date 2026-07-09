using ConferenceRoomBooking.Application.Commands.ConferenceRoom;
using ConferenceRoomBooking.Application.DTOs.Requests.ConferenceRoom;
using ConferenceRoomBooking.Application.DTOs.Responses.ConferenceRoom;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Application.Queries.ConferenceRoom;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceRoomsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailableConferenceRoomRespons>>> GetAvailableRooms([FromServices] IRequestHandler<GetAvailableConferenceRoomsQuery, IEnumerable<AvailableConferenceRoomRespons>> requestHendler,
            [FromBody] AvailableConferenceRoomRequest availableConferenceRoom)
        {
            var query = new GetAvailableConferenceRoomsQuery
            {
                StartDateTime = availableConferenceRoom.StartAt,
                DurationHours = availableConferenceRoom.DurationHours,
                Capacity = availableConferenceRoom.Capacity
            };

            return Ok(await requestHendler.HandlerAsync(query));
        }

        [HttpPost]
        public async Task<IActionResult> AddConferenceRoom([FromServices] IRequestHandler<AddConferenceRoomCommand, AddConferenceRoomResponse> addConferenceRoomCommand, 
            [FromBody] AddConferenceRoomRequest conferenceRoomRequest)
        {
            var conferenceRoomCommand = new AddConferenceRoomCommand
            {
                Name = conferenceRoomRequest.Name,
                Capacity = conferenceRoomRequest.Capacity,
                BasePrice = conferenceRoomRequest.BasePrice
            };

            var result = await addConferenceRoomCommand.HandlerAsync(conferenceRoomCommand);
            if(result.Status <= 0)
            {
                return BadRequest("Failed to add conference room.");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpsertConferenceRoom([FromServices] IRequestHandler<UpsertConferenceRoomCommand, int> upsertConferenceRoomCommand, 
            [FromBody] UpsertConferenceRoomRequest upsertConferenceRoomRequest)
        {
            var result = await upsertConferenceRoomCommand.HandlerAsync(new UpsertConferenceRoomCommand
            {
                Id = upsertConferenceRoomRequest.Id,
                Name = upsertConferenceRoomRequest.Name,
                Capacity = upsertConferenceRoomRequest.Capacity,
                BasePrice = upsertConferenceRoomRequest.BasePrice
            });

            if (result <= 0)
            {
                return BadRequest("Failed to update conference room.");
            }

            return Ok(200);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteConferenceRoom([FromServices] IRequestHandler<DeleteConferenceRoomCommand, int> deleteConferenceRoomCommand,
            Guid idRequest)
        {
            var result = await deleteConferenceRoomCommand.HandlerAsync(new DeleteConferenceRoomCommand
            {
                Id = idRequest
            });

            if (result <= 0)
            {
                return BadRequest("Failed to delete conference room.");
            }

            return Ok(200);
        }
    }
}
