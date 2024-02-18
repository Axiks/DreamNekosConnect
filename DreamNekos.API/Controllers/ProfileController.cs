using AutoMapper;
using DreamNekos.API.Helpers;
using DreamNekos.API.Request.Profile;
using DreamNekos.API.Request.Profile.Interest;
using DreamNekos.API.Response.Interest;
using DreamNekos.API.Response.Link;
using DreamNekos.API.Response.Profile;
using DreamNekos.Core;
using DreamNekos.Core.Entities;
using DreamNekosConnect.Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace DreamNekos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiKey]
    [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
    public class ProfileController : ControllerBase
    {
        private ProfileService _profileService;
        private readonly IMapper _mapper;
        public ProfileController(IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _profileService = new ProfileService(applicationDbContext);
            _mapper = mapper;
        }

        [ApiKey]
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<GetProfileResponse>))]
        public IActionResult GetProfileList()
        {
            List<UserEntity> result = _profileService.GetProfiles();
            List<GetProfileResponse> response = _mapper.Map<List<GetProfileResponse>>(result);
            return Ok(response);
        }

        [ApiKey]
        [HttpGet("{userId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetProfileResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult GetProfile(Guid userId)
        {
            var result = _profileService.GetProfileById(userId);
            GetProfileResponse response = _mapper.Map<GetProfileResponse>(result);
            return Ok(response);
        }

        [ApiKey]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetProfileResponse))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        public IActionResult CreateProfile(CreateProfileRequest request)
        {
            var result = _profileService.CreateProfile(request.TgId, request.Name, request.About);
            var response = _mapper.Map<GetProfileResponse>(result);
            return Ok(response);
        }

        [ApiKey]
        [HttpPut("{userId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetProfileResponse))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult UpdateProfile(Guid userId, UpdateProfileRequest updateProfileRequest)
        {
            var result = _profileService.UpdateProfile(userId: userId, name: updateProfileRequest.Name, about: updateProfileRequest.About);
            var response = _mapper.Map<GetProfileResponse>(result);
            return Ok(response);
        }
        /*[HttpGet("profileFromTg/{tgUserId}")]
        public IActionResult GetTelegramChatUsers(int tgId)
        {
            //GetProfileListResponse
            return Ok();
        }*/
        /*[HttpGet("{userId}/interests")]
        public IActionResult GetAllProfileInterest(Guid userId)
        {
            var result = _profileService.GetAllInterest(userId);

            var response = _mapper.Map<List<UserInterestEntity>, List<InterestResponse>>(result);
            return Ok(response);
        }*/

        [ApiKey]
        [HttpPost("{userId}/interests")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InterestResponse))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult AddInterest(Guid userId, AddUserInterestRequest addInterestRequest)
        {
            var result = _profileService.AddInterest(userId, addInterestRequest.interestId, addInterestRequest.familiarizationLevel);
            var response = _mapper.Map<InterestResponse>(result);
            return Ok(response);
        }

        [ApiKey]
        [HttpDelete("{userId}/interests/{interestId}")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult RemoveInterest(Guid userId, Guid interestId)
        {
            _profileService.RemoveInterest(userId, interestId);
            return Ok();
        }

        [ApiKey]
        [HttpPost("{userId}/links")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(LinkResponse))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult CreateLink(Guid userId, string name, string url)
        {
            var result = _profileService.CreateLink(userId, name, url);
            var response = _mapper.Map<LinkResponse>(result);
            return Ok(response);
        }

        [ApiKey]
        [HttpDelete("{userId}/links/{linkId}")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteLink(Guid userId, Guid linkId)
        {
            _profileService.DeleteLink(userId, linkId);
            return Ok();
        }
    }
}
