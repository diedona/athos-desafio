using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Infra.Generated;
using DDonah.AthosDesafio.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDonah.AthosDesafio.Services
{
    public class MensagemService : BaseService<Mensagem>, IMensagemService
    {
        public MensagemService(AthosDesafioContext db) : base(db) { }

        public override IEnumerable<Mensagem> GetAll()
        {
            return _db.Mensagem
                .Include(x => x.UsuarioEmissor)
                .Include(x => x.Assunto)
                .Include(x => x.AdministradoraResponsavel)
                .Include(x => x.UsuarioResponsavel)
                .OrderByDescending(x => x.DateCreated)
                .ToList();
        }

        public override Mensagem Get(int id)
        {
            return _db.Mensagem
                .Include(x => x.UsuarioEmissor)
                .Include(x => x.Assunto)
                .Include(x => x.AdministradoraResponsavel)
                .Include(x => x.UsuarioResponsavel)
                .FirstOrDefault(x => x.Id == id);
        }

        public override void Save(Mensagem entity)
        {
            int usuarioEmissorId = entity.UsuarioEmissorId;
            Usuario usuarioEmissor = _db.Usuario.FirstOrDefault(x => x.Id == usuarioEmissorId);
            Condominio condominioDoUsuarioEmissor = _db.Condominio.FirstOrDefault(x => x.Id == usuarioEmissor.CondominioId);
            Assunto assunto = _db.Assunto.FirstOrDefault(x => x.Id == entity.AssuntoId);

            if (assunto.Tipo.Equals("Condominal"))
            {
                if (condominioDoUsuarioEmissor.UsuarioSindicoId.HasValue)
                {
                    entity.AdministradoraResponsavelId = null;
                    entity.UsuarioResponsavelId = condominioDoUsuarioEmissor.UsuarioSindicoId.Value;
                }
                else if(condominioDoUsuarioEmissor.UsuarioZeladorId.HasValue)
                {
                    entity.AdministradoraResponsavelId = null;
                    entity.UsuarioResponsavelId = condominioDoUsuarioEmissor.UsuarioZeladorId.Value;
                }
                else
                {
                    throw new ArgumentException("O condomínio não possui síndico nem zelador para receber a mensagem!");
                }
            }
            else
            {
                entity.AdministradoraResponsavelId = condominioDoUsuarioEmissor.AdministradoraId;
                entity.UsuarioResponsavelId = null;
            }

            entity.DateCreated = DateTime.Now;
            base.Save(entity);
        }
    }
}
