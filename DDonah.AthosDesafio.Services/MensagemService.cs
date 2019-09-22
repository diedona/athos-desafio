using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Infra.Generated;
using DDonah.AthosDesafio.Services.Base;
using System.Linq;

namespace DDonah.AthosDesafio.Services
{
    public class MensagemService : BaseService<Mensagem>, IMensagemService
    {
        public MensagemService(AthosDesafioContext db) : base(db) { }

        public override void Save(Mensagem entity)
        {
            int usuarioEmissorId = entity.UsuarioEmissorId;
            Usuario usuarioEmissor = _db.Usuario.FirstOrDefault(x => x.Id == usuarioEmissorId);
            Condominio condominioDoUsuarioEmissor = _db.Condominio.FirstOrDefault(x => x.Id == usuarioEmissor.CondominioId);

            // SE O CONDOMINIO TEM UM RESPONSÁVEL, ENVIAR PARA ELE
            if (condominioDoUsuarioEmissor.ResponsavelId.HasValue)
            {
                entity.AdministradoraResponsavelId = null;
                entity.UsuarioResponsavelId = condominioDoUsuarioEmissor.ResponsavelId.Value;
            }
            // CASO CONTRÁRIO, SERÁ PARA A ADMINISTRADORA
            else
            {
                entity.UsuarioResponsavelId = null;
                entity.AdministradoraResponsavelId = condominioDoUsuarioEmissor.AdministradoraId;
            }

            base.Save(entity);
        }
    }
}
