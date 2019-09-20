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
    public class UsuarioServiceTest
    {
        private readonly AthosDesafioContext _db;

        public UsuarioServiceTest()
        {
            _db = DbMock.GetContextWithData();
        }

        [Test]
        public void Usuario_NaoDeveInserir_TipoUsuarioInvalido()
        {
            UsuarioService usuarioService = new UsuarioService(_db);
            Usuario usuarioFail = getUsuarioComTipoInvalido();
            Assert.Throws<ArgumentException>(() => usuarioService.Save(usuarioFail));
        }

        [Test]
        public void Usuario_NaoDeveInserir_SemTipoUsuario()
        {
            UsuarioService usuarioService = new UsuarioService(_db);
            Usuario usuarioFail = getUsuarioComTipoInvalido();
            usuarioFail.Tipo = string.Empty;
            Assert.Throws<ArgumentException>(() => usuarioService.Save(usuarioFail));
        }

        private Usuario getUsuarioComTipoInvalido()
        {
            return new Usuario()
            {
                Nome = "INVALIDO",
                Email = "INVI@MORA.COM",
                Tipo = "N/A",
                CondominioId = _db.Condominio.FirstOrDefault().Id
            };
        }
    }
}
