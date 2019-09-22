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
            CreateMapMensagem();
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

        private void CreateMapMensagem()
        {
            CreateMap<Mensagem, MensagemViewModel>()
                .ForMember(dest => dest.AssuntoTipo, opt =>
                {
                    opt.Condition(x => x.Assunto != null);
                    opt.MapFrom(x => x.Assunto.Tipo);
                })
                .ForMember(dest => dest.UsuarioEmissorNome, opt =>
                {
                    opt.Condition(x => x.UsuarioEmissor != null);
                    opt.MapFrom(x => x.UsuarioEmissor.Nome);
                })
                .ForMember(dest => dest.AdministradoraResponsavelNome, opt =>
                {
                    opt.Condition(x => x.AdministradoraResponsavelId.HasValue);
                    opt.MapFrom(x => x.AdministradoraResponsavel.Nome);
                })
                .ForMember(dest => dest.UsuarioResponsavelNome, opt =>
                {
                    opt.Condition(x => x.UsuarioResponsavelId.HasValue);
                    opt.MapFrom(x => x.UsuarioResponsavel.Nome);
                });

            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
