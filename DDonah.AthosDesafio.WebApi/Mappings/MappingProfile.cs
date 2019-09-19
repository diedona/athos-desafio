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
            CreateMapCondominio();
        }

        private void CreateMapCondominio()
        {
            CreateMap<Condominio, CondominioViewModel>()
                .ForMember(dest => dest.ResponsavelNome, opt => opt.MapFrom(x => x.Responsavel.Nome))
                .ForMember(dest => dest.ResponsavelCargo, opt => opt.MapFrom(x => x.Responsavel.Tipo))
                .ForMember(dest => dest.ResponsavelEmail, opt => opt.MapFrom(x => x.Responsavel.Email));
        }
    }
}
