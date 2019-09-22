using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Services.Base;
using System.Collections.Generic;

namespace DDonah.AthosDesafio.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        string[] GetTiposDeUsuario();
        IEnumerable<Usuario> GetResponsavel();
    }
}