using DreamNekos.API.Helpers;
using DreamNekos.API.Request.InterestType;
using DreamNekos.API.Response.InterestType;
using DreamNekosConnect.Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace DreamNekos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InterestTypeController : ControllerBase
    {
        private InterestTypeService _interestTypeService;

        public InterestTypeController(InterestTypeService interestTypeService)
        {
            _interestTypeService = interestTypeService;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<InterestTypeResponse>))]
        [HttpGet]
        public IActionResult IndexInterestType() {
            List<InterestTypeResponse> interestTypeResponses = new List<InterestTypeResponse>();
            var  result = _interestTypeService.GetAllInterestType();
            foreach(var item in result)
            {
                interestTypeResponses.Add(new InterestTypeResponse
                {
                    InterestTypeId = item.Id,
                    Name = item.Name,
                });
            }
            return Ok(interestTypeResponses);

        }

        [HttpGet("{interestTypeId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InterestTypeResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult GetInterestType(Guid interestTypeId)
        {
            var interestType = _interestTypeService.GetInterestType(interestTypeId);
            var response = new InterestTypeResponse { InterestTypeId = interestType.Id, Name = interestType.Name };
            return Ok(response);
        }

        [ApiKey]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InterestTypeResponse))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        public IActionResult CreateInterestType(CreateInterestTypeRequest createInterestTypeRequest)
        {
            var newInterestType = _interestTypeService.CreateInterestType(createInterestTypeRequest.Name);
            var response = new InterestTypeResponse { InterestTypeId = newInterestType.Id, Name = newInterestType.Name };
            return Ok(response);
        }

        [ApiKey]
        [HttpPut("{interestTypeId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InterestTypeResponse))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult UpdateInterestType(Guid interestTypeId, UpdateInterestTypeRequest updateInterestTypeRequest)
        {
            var interestType = _interestTypeService.UpdateInterestType(interestTypeId, updateInterestTypeRequest.Name);
            var response = new InterestTypeResponse { InterestTypeId = interestType.Id, Name = interestType.Name };
            return Ok(response);
        }

        [ApiKey]
        [HttpDelete("{interestTypeId}")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteInterestType(Guid interestTypeId)
        {
            _interestTypeService.DeleteInterestType(interestTypeId);
            return Ok();
        }
    }
}
