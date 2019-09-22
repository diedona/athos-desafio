using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Infra.Generated;
using DDonah.AthosDesafio.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
                .Include(x => x.CondominioNavigation)
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
            // CHECAR SE É RESPONSÁVEL DE ALGUM CONDOMINIO
            if (_db.Condominio.Any(x => x.ResponsavelId.HasValue && x.ResponsavelId.Value == id))
            {
                throw new InvalidOperationException("Este usuário é responsável por um condomínio e não pode ser excluído!");
            }

            base.Delete(id);
        }

        public override IEnumerable<Usuario> GetAll()
        {
            return _db.Usuario
                .Include(x => x.CondominioNavigation)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public IEnumerable<Usuario> GetResponsavel()
        {
            return _db.Usuario
                .Where(x => this.usuarioTipoResponsaveis.Contains(x.Tipo))
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
