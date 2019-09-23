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
                .ForMember(dest => dest.UsuarioSindicoNome, opt => opt.MapFrom(x => x.UsuarioSindico.Nome))
                .ForMember(dest => dest.UsuarioZeladorNome, opt => opt.MapFrom(x => x.UsuarioZelador.Nome));

            CreateMap<CondominioViewModel, Condominio>();
        }

        private void CreateMapUsuario()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.CondominioNome, opt => opt.MapFrom(x => x.Condominio.Nome));

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

            CreateMap<MensagemViewModel, Mensagem>();
        }
    }
}
