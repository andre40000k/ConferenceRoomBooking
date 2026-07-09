using ConferenceRoomBooking.Application.Commands.Service;
using ConferenceRoomBooking.Application.DTOs.Requests.Service;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddService([FromServices] IRequestHandler<UpsertServiceCommand> upsertServiceCommand , [FromBody] ServiceRequest serviceRequest)
        {
            var service = new UpsertServiceCommand
            {
                Name = serviceRequest.Name,
                Price = serviceRequest.Price
            };

            await upsertServiceCommand.HandlerAsync(service);

            return Ok(200);
        }
    }
}
