using DreamNekos.API.Helpers;
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
        private ActivityService _interestService;

        public InterestController(ActivityService interestService)
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
                var interest = new InterestResponse
                {
                    InterestId = item.Id,
                    Name = item.Name
                };
                interestListResponse.Add(interest);
                if (item.InterestTypeId == null) { continue; }
                interest.InterestType = new InterestTypeResponse { InterestTypeId = item.InterestType.Id, Name = item.InterestType.Name };
            }

            return Ok(interestListResponse);
        }

        [ApiKey]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InterestResponse))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        public IActionResult CreateInterest(CreateInterestRequest createInterestRequest)
        {
            var newInterest = _interestService.CreateInterest(createInterestRequest.Name, createInterestRequest.InterestTypeId);
            //GetInterestResponse
            var newInterestType = new InterestTypeResponse { InterestTypeId = newInterest.InterestType.Id, Name = newInterest.InterestType.Name };
            var response = new InterestResponse { InterestId = newInterest.Id, InterestType = newInterestType, Name = newInterest.Name };
            return Ok(response);
        }

        [ApiKey]
        [HttpPut("{interestId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InterestResponse))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult EditInterest(Guid interestId, UpdateInterestRequest updateInterestRequest)
        {
            var updatedInterst = _interestService.UpdateInterest(interestId, updateInterestRequest.Name, updateInterestRequest.InterestTypeId);
            var updatedInterestType = new InterestTypeResponse { InterestTypeId = updatedInterst.InterestType.Id, Name = updatedInterst.InterestType.Name };
            var response = new InterestResponse { InterestId = updatedInterst.Id, Name = updatedInterst.Name, InterestType = updatedInterestType };
            //GetInterestResponse
            return Ok(response);
        }

        [ApiKey]
        [HttpDelete("{interestId}")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteInterest(Guid interestId)
        {
            _interestService.DeleteInterest(interestId);
            return Ok();
        }
    }
}
