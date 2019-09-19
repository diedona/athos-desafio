using AutoMapper;
using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDonah.AthosDesafio.WebApi.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Administradora, AdministradoraViewModel>().ReverseMap();
        }
    }
}
