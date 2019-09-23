using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Infra.Generated;
using DDonah.AthosDesafio.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDonah.AthosDesafio.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly string[] usuarioTipos = new string[] { "MORADOR", "SINDICO", "ADMINISTRADOR", "ZELADOR" };
        private readonly string[] usuarioTipoResponsaveis = new string[] { "SINDICO", "ZELADOR" };

        public UsuarioService(AthosDesafioContext db) : base(db) { }

        public override Usuario Get(int id)
        {
            return _db.Usuario
                .Include(x => x.Condominio)
                .FirstOrDefault(x => x.Id == id);
        }

        public override void Save(Usuario entity)
        {
            if (string.IsNullOrEmpty(entity.Tipo))
            {
                throw new ArgumentException("É necessário definir um tipo para o usuário");
            }
            if (!usuarioTipos.Contains(entity.Tipo))
            {
                throw new ArgumentException($"Tipo '{entity.Tipo}' é inválido para um usuário");
            }

            base.Save(entity);
        }

        public override void Delete(int id)
        {
            StringBuilder sb = new StringBuilder();

            // CHECAR SE É SÍNDICO DE ALGUM CONDOMINIO
            if (_db.Condominio.Any(x => x.UsuarioSindicoId.HasValue && x.UsuarioSindicoId.Value == id))
            {
                sb.AppendLine("Este usuário é sindico de um condomínio e não pode ser excluído!");
            }

            // CHECAR SE É ZELADOR DE ALGUM CONDOMINIO
            if (_db.Condominio.Any(x => x.UsuarioZeladorId.HasValue && x.UsuarioZeladorId.Value == id))
            {
                sb.AppendLine("Este usuário é zelador de um condomínio e não pode ser excluído!");
            }

            // CHECAR SE É DONO DE ALGUMA MENSAGEM
            if(_db.Mensagem.Any(x => x.UsuarioEmissorId == id))
            {
                sb.AppendLine("Este usuário é emissor de uma mensagem e não pode ser excluído!");
            }

            // CHECAR SE É RESPONSÁVEL DE ALGUMA MENSAGEM
            if (_db.Mensagem.Any(x => x.UsuarioResponsavelId.HasValue && x.UsuarioResponsavelId.Value == id))
            {
                sb.AppendLine("Este usuário é responsável por uma mensagem e não pode ser excluído!");
            }

            string error = sb.ToString();
            if (string.IsNullOrEmpty(error))
            {
                base.Delete(id);
            }
            else
            {
                throw new ArgumentException(error);
            }
        }

        public override void Update(Usuario entity)
        {
            string dbTipo = _db.Usuario.Where(x => x.Id == entity.Id).Select(x => x.Tipo).FirstOrDefault();
            if (dbTipo.Equals(entity.Tipo))
            {
                base.Update(entity);
            }
            else
            {
                throw new ArgumentException($"Tentativa de mudar o Tipo do usuário ({dbTipo} => {entity.Tipo}). Operação cancelada.");
            }
        }

        public override IEnumerable<Usuario> GetAll()
        {
            return _db.Usuario
                .Include(x => x.Condominio)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public IEnumerable<Usuario> GetSindico()
        {
            return _db.Usuario
                .Where(x => x.Tipo.Equals("SINDICO"))
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public IEnumerable<Usuario> GetZelador()
        {
            return _db.Usuario
                .Where(x => x.Tipo.Equals("ZELADOR"))
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public IEnumerable<Usuario> GetMorador()
        {
            return _db.Usuario
                .Where(x => x.Tipo.Equals("MORADOR"))
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public string[] GetTiposDeUsuario()
        {
            return this.usuarioTipos;
        }
    }
}
