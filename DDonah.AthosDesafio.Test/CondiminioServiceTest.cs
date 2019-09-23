using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Infra.Generated;
using DDonah.AthosDesafio.Services;
using DDonah.AthosDesafio.Test.Db;
using NUnit.Framework;
using System;
using System.Linq;

namespace DDonah.AthosDesafio.Test
{
    [TestFixture]
    public class CondiminioServiceTest
    {
        private readonly AthosDesafioContext _db;

        public CondiminioServiceTest()
        {
            _db = DbMock.GetContextWithData();
        }

        [Test]
        public void Condominio_NaoDeveInserir_TipoResponsavelInvalido()
        {
            CondominioService condominioService = new CondominioService(_db);
            Condominio condominioFail = getCondominioComResponsavelMorador();
            Assert.Throws<ArgumentException>(() => condominioService.Save(condominioFail));
        }

        [Test]
        public void Condominio_DeveInserir()
        {
            CondominioService condominioService = new CondominioService(DbMock.GetContextWithData());
            Condominio condominioSuccess = getCondominioNormalizado();
            Assert.DoesNotThrow(() => condominioService.Save(condominioSuccess));
        }

        private Condominio getCondominioComResponsavelMorador()
        {
            return new Condominio()
            {
                Nome = "TesteCondominio",
                AdministradoraId = 1,
                UsuarioSindicoId = _db.Usuario.FirstOrDefault(x => x.Tipo.Equals("MORADOR")).Id
            };
        }

        private Condominio getCondominioNormalizado()
        {
            return new Condominio()
            {
                Nome = "TesteCondominioNormal",
                AdministradoraId = 1,
                UsuarioSindicoId = _db.Usuario.FirstOrDefault(x => x.Tipo.Equals("SINDICO")).Id
            };
        }
    }
}
