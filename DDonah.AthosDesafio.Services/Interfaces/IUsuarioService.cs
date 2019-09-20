using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Services.Base;

namespace DDonah.AthosDesafio.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        string[] GetTiposDeUsuario();
    }
}