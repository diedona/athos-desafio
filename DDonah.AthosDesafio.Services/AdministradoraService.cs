﻿using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Infra.Generated;
using DDonah.AthosDesafio.Services.Base;
using System.Collections.Generic;
using System.Linq;

namespace DDonah.AthosDesafio.Services
{
    public class AdministradoraService : BaseService<Administradora>, IAdministradoraService
    {
        public AdministradoraService(AthosDesafioContext db) : base(db) { }

        public override IEnumerable<Administradora> GetAll()
        {
            return _db.Administradora
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public Administradora GetByNome(string nome)
        {
            return _dbSet.Where(x => x.Nome.Equals(nome)).FirstOrDefault();
        }
    }
}
