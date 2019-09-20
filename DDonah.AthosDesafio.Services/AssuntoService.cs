using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Infra.Generated;
using DDonah.AthosDesafio.Services.Base;

namespace DDonah.AthosDesafio.Services
{
    public class AssuntoService : BaseService<Assunto>, IAssuntoService
    {
        public AssuntoService(AthosDesafioContext db) : base(db) { }
    }
}
