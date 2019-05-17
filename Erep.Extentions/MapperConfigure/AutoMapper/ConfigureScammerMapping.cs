using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Erep.DomainClasses.Models;
using Erep.ViewModels.ViewModels;

namespace Erep.Extentions.MapperConfigure.AutoMapper
{
    public class ConfigureScammerMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Scammer, ScammerViewModel>();
            Mapper.CreateMap<ScammerViewModel, Scammer>();

            //Mapper.CreateMap<Project, ProjectViewModel>()
            //    .ForMember(dest => dest.ContactListName,
            //    option => option.MapFrom(src => src.ContactList.Name));
            //Mapper.CreateMap<ProjectViewModel, Project>()
            //    .ForMember(dest => dest.ContactListId,
            //    option => option.Ignore());
        }
    }
}
