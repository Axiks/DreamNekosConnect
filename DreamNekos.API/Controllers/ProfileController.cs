using AutoMapper;
using DreamNekos.API.Request.Profile;
using DreamNekos.API.Request.Profile.Interest;
using DreamNekos.API.Response.Interest;
using DreamNekos.API.Response.Link;
using DreamNekos.API.Response.Profile;
using DreamNekosConnect.Lib;
using DreamNekosConnect.Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace DreamNekos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private ProfileService _profileService;
        private readonly IMapper _mapper;
        public ProfileController(IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _profileService = new ProfileService(applicationDbContext);
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetProfileResponse))]
        public IActionResult GetProfile(Guid userId)
        {
            var result = _profileService.GetProfileById(userId);
            GetProfileResponse response = _mapper.Map<GetProfileResponse>(result);
            return Ok(response);
        }
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetProfileResponse))]
        public IActionResult CreateProfile(CreateProfileRequest request)
        {
            var result = _profileService.CreateProfile(request.TgId, request.Name, request.About);
            var response = _mapper.Map<GetProfileResponse>(result);
            return Ok(response);
        }
        [HttpPut("{userId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetProfileResponse))]
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
        [HttpPost("{userId}/interests")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InterestResponse))]
        public IActionResult AddInterest(Guid userId, AddUserInterestRequest addInterestRequest)
        {
            var result = _profileService.AddInterest(userId, addInterestRequest.interestId, addInterestRequest.familiarizationLevel);
            var response = _mapper.Map<InterestResponse>(result);
            return Ok(response);
        }
        [HttpDelete("{userId}/interests/{interestId}")]
        public IActionResult RemoveInterest(Guid userId, Guid interestId)
        {
            _profileService.RemoveInterest(userId, interestId);
            return Ok();
        }
        [HttpPost("{userId}/links")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(LinkResponse))]
        public IActionResult CreateLink(Guid userId, string name, string url)
        {
            var result = _profileService.CreateLink(userId, name, url);
            var response = _mapper.Map<LinkResponse>(result);
            return Ok(response);
        }
        [HttpDelete("{userId}/links/{linkId}")]
        public IActionResult DeleteLink(Guid userId, Guid linkId)
        {
            _profileService.DeleteLink(userId, linkId);
            return Ok();
        }
    }
}
