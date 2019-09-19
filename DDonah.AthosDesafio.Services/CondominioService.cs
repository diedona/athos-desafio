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
    public class CondominioService : BaseService<Condominio>, ICondominioService
    {
        public CondominioService(AthosDesafioContext db) : base(db) { }

        public override IEnumerable<Condominio> GetAll()
        {
            return _db.Condominio
                .Include(x => x.Responsavel)
                .ToList();
        }
    }
}
