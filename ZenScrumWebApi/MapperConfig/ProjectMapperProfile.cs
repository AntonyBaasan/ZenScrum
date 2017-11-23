using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc.Routing;
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