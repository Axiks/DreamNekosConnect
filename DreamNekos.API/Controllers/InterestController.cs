using DreamNekos.API.Request.Interest;
using DreamNekos.API.Response.Interest;
using DreamNekos.API.Response.InterestType;
using DreamNekosConnect.Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace DreamNekos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private InterestService _interestService;

        public InterestController(InterestService interestService)
        {
            _interestService = interestService;
        }
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<InterestResponse>))]
        public IActionResult IndexInterest()
        {
            var interestListResponse = new List<InterestResponse>();
            var avaibleInterestList = _interestService.GetAllInterest();
            foreach (var item in avaibleInterestList)
            {
                var interestType = new InterestTypeResponse { InterestTypeId = item.InterestType.Id, Name = item.InterestType.Name };
                interestListResponse.Add(new InterestResponse
                {
                    InterestId = item.Id,
                    Name = item.Name,
                    InterestType = interestType
                });
            }

            return Ok(interestListResponse);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InterestResponse))]
        public IActionResult CreateInterest(CreateInterestRequest createInterestRequest)
        {
            var newInterest = _interestService.CreateInterest(createInterestRequest.Name, createInterestRequest.InterestTypeId);
            //GetInterestResponse
            var newInterestType = new InterestTypeResponse { InterestTypeId = newInterest.InterestType.Id, Name = newInterest.InterestType.Name };
            var response = new InterestResponse { InterestId = newInterest.Id, InterestType = newInterestType, Name = newInterest.Name };
            return Ok(response);
        }
        [HttpPut("{interestId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InterestResponse))]
        public IActionResult EditInterest(Guid interestId, UpdateInterestRequest updateInterestRequest)
        {
            var updatedInterst = _interestService.UpdateInterest(interestId, updateInterestRequest.Name, updateInterestRequest.InterestTypeId);
            var updatedInterestType = new InterestTypeResponse { InterestTypeId = updatedInterst.InterestType.Id, Name = updatedInterst.InterestType.Name };
            var response = new InterestResponse { InterestId = updatedInterst.Id, Name = updatedInterst.Name, InterestType = updatedInterestType };
            //GetInterestResponse
            return Ok(response);
        }
        [HttpDelete("{interestId}")]
        public IActionResult DeleteInterest(Guid interestId)
        {
            return Ok();
        }
    }
}
