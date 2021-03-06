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
                .Include(x => x.UsuarioSindico)
                .Include(x => x.UsuarioZelador)
                .Include(x => x.Administradora)
                .ToList();
        }

        public override Condominio Get(int id)
        {
            return _db.Condominio
                .Include(x => x.UsuarioSindico)
                .Include(x => x.UsuarioZelador)
                .Include(x => x.Administradora)
                .FirstOrDefault(x => x.Id == id);
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

        public override void Delete(int id)
        {
            // CHECAR SE TEM ALGUM USUARIO MORANDO NELE
            if (_db.Usuario.Any(x => x.CondominioId == id))
            {
                throw new InvalidOperationException("Este condomínio pois moradores e não pode ser excluído!");
            }

            base.Delete(id);
        }

        private void checkResponsavelTipoThrowException(Condominio entity)
        {
            if(entity.UsuarioSindicoId.HasValue)
            {
                var usuario = _db.Usuario.Find(entity.UsuarioSindicoId.Value);
                if(!usuario.Tipo.Equals("SINDICO"))
                {
                    throw new ArgumentException($"O usuário indicado para síndico é do tipo '{usuario.Tipo}'!");
                }
            }

            if (entity.UsuarioZeladorId.HasValue)
            {
                var usuario = _db.Usuario.Find(entity.UsuarioZeladorId.Value);
                if (!usuario.Tipo.Equals("ZELADOR"))
                {
                    throw new ArgumentException($"O usuário indicado para zelador é do tipo '{usuario.Tipo}'!");
                }
            }
        }
    }
}
