﻿using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Infra.Generated;
using DDonah.AthosDesafio.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDonah.AthosDesafio.Services
{
    public class CondominioService : BaseService<Condominio>, ICondominioService
    {
        private readonly string[] tiposDeResponsavelValidos = new string[] { "ZELADOR", "SINDICO" };

        public CondominioService(AthosDesafioContext db) : base(db) { }

        public override IEnumerable<Condominio> GetAll()
        {
            return _db.Condominio
                .Include(x => x.Responsavel)
                .ToList();
        }

        public override void Save(Condominio entity)
        {
            this.checkResponsavelTipoThrowException(entity);
            base.Save(entity);
        }

        public override void Update(Condominio entity)
        {
            this.checkResponsavelTipoThrowException(entity);
            base.Update(entity);
        }

        private void checkResponsavelTipoThrowException(Condominio entity)
        {
            if (entity.ResponsavelId.HasValue)
            {
                // Responsável só pode ser (( Zelador / Sindico ))
                var responsavel = _db.Usuario.Find(entity.ResponsavelId);
                if (!this.tiposDeResponsavelValidos.Contains(responsavel.Tipo))
                {
                    throw new ArgumentException("Tipo de responsável inválido");
                }
            }
        }
    }
}
