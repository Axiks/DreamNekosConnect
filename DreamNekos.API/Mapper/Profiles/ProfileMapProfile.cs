using AutoMapper;
using DreamNekos.API.Response.Interest;
using DreamNekos.API.Response.InterestType;
using DreamNekos.API.Response.Link;
using DreamNekos.API.Response.Profile;
using DreamNekos.API.Response.Profile.Interest;
using DreamNekos.Core.Entities;
using DreamNekos.Core.Entities.Activity;
using DreamNekosConnect.Lib.Entities;

namespace DreamNekos.API.Mapper.Profiles
{
    public class ProfileMapProfile : Profile
    {
        public ProfileMapProfile() {
            CreateMap<UserEntity, GetProfileResponse>();
            CreateMap<UserActivityEntity, InterestResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Actvity.Name))
                .ForMember(dest => dest.InterestType, opt => opt.MapFrom(src => src.Actvity.InterestType));
            CreateMap<ActivityTypeEntity, InterestTypeResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.InterestTypeId, opt => opt.MapFrom(src => src.Id));
            CreateMap<LinkEntity, LinkResponse>()
                .ForMember(dest => dest.LinkId, opt  => opt.MapFrom(src => src.Id));
            CreateMap<UserEntity, GetProfileResponse>()
                .ForMember(dest => dest.Interest, opt => opt.MapFrom(src => src.UserInterest));
            CreateMap<ActivityEntity, InterestResponse>()
                .ForMember(dest => dest.InterestId, opt => opt.MapFrom(src => src.Id));
            CreateMap<UserActivityEntity, UserInterestLinkResponse>();
        }
    }
}
