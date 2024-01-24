using AutoMapper;
using Portal.EntityLayer;
using Portal.WEBUI.Dtos.AppUserProfileDto;
using Portal.WEBUI.Dtos.EducationDto;
using Portal.WEBUI.Dtos.UserEducationDto;

namespace Portal.WEBUI.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Education, ResultEducationDto>().ReverseMap();
            CreateMap<Education, CreateEducationDto>().ReverseMap();
            CreateMap<Education, UpdateEducationDto>().ReverseMap();

            CreateMap<UserEducation, ResultUserEducationDto>().ReverseMap();

            CreateMap<AppUserProfile, ResultAppUserProfileDto>().ReverseMap();
            CreateMap<AppUserProfile, UpdateAppUserProfileDto>().ReverseMap();
        }
    }
}
