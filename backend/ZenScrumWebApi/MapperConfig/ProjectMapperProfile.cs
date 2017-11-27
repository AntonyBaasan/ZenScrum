using AutoMapper;
using Domain;
using ZenScrumWebApi.Dto;

namespace ZenScrumWebApi.MapperConfig
{
    public class ProjectMapperProfile : Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<Project, ProjectDto>()
                .ForMember(c=> c.Url, opt=> opt.ResolveUsing<ProjectUrlResolver>())
                .ReverseMap();
        }
    }
}