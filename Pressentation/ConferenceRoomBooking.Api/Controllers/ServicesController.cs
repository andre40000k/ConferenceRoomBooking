using ConferenceRoomBooking.Application.Commands.Service;
using ConferenceRoomBooking.Application.DTOs.Requests.Service;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceRoomBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        //// GET: api/<ServicesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ServicesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ServicesController>
        [HttpPost]
        public async Task<IActionResult> AddService([FromServices] IRequestHendler<UpsertServiceCommand> upsertServiceCommand , [FromBody] ServiceRequest serviceRequest)
        {
            var service = new UpsertServiceCommand
            {
                Name = serviceRequest.Name,
                Price = serviceRequest.Price
            };

            await upsertServiceCommand.HendlerAsync(service);

            return Ok(200);
        }

        //// PUT api/<ServicesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ServicesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
