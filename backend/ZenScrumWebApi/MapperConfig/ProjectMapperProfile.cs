﻿using AutoMapper;
using Domain;
using MongoDB.Bson;
using ZenScrumWebApi.Dto;

namespace ZenScrumWebApi.MapperConfig
{
    public class ProjectMapperProfile : Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<Project, ProjectDto>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(c => c.Url, opt => opt.ResolveUsing<ProjectUrlResolver>())
                .ReverseMap()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? ObjectId.Empty : ObjectId.Parse(src.Id)));
        }
    }
}