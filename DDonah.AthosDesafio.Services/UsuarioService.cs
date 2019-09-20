using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Infra.Generated;
using DDonah.AthosDesafio.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DDonah.AthosDesafio.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly string[] usuarioTipos = new string[] { "MORADOR", "SINDICO", "ADMINISTRADOR", "ZELADOR" };

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

        public string[] GetTiposDeUsuario()
        {
            return this.usuarioTipos;
        }
    }
}
