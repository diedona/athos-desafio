using AutoMapper;
using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.WebApi.ViewModel;

namespace DDonah.AthosDesafio.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Administradora, AdministradoraViewModel>().ReverseMap();
            CreateMapCondominio();
            CreateMapUsuario();
            CreateMapAssunto();
        }

        private void CreateMapCondominio()
        {
            CreateMap<Condominio, CondominioViewModel>()
                .ForMember(dest => dest.AdministradoraNome, opt => opt.MapFrom(x => x.Administradora.Nome))
                .ForMember(dest => dest.ResponsavelNome, opt => opt.MapFrom(x => x.Responsavel.Nome))
                .ForMember(dest => dest.ResponsavelCargo, opt => opt.MapFrom(x => x.Responsavel.Tipo))
                .ForMember(dest => dest.ResponsavelEmail, opt => opt.MapFrom(x => x.Responsavel.Email));

            CreateMap<CondominioViewModel, Condominio>();
        }

        private void CreateMapUsuario()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.CondominioNome, opt =>
                {
                    opt.Condition(x => x.CondominioNavigation != null);
                    opt.MapFrom(x => x.CondominioNavigation.Nome);
                });

            CreateMap<UsuarioViewModel, Usuario>();
        }

        private void CreateMapAssunto()
        {
            CreateMap<Assunto, AssuntoViewModel>().ReverseMap();
        }
    }
}
