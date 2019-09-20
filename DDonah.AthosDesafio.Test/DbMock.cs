using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Infra.Generated;
using Microsoft.EntityFrameworkCore;

namespace DDonah.AthosDesafio.Test
{
    /// <summary>
    /// https://gunnarpeipman.com/aspnet-core-ef-inmemory/
    /// </summary>
    public class DbMock
    {
        public static AthosDesafioContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<AthosDesafioContext>()
                              .UseInMemoryDatabase("athos-desafio-in-memory")
                              .Options;

            var context = new AthosDesafioContext(options);
            context.Database.EnsureDeleted();

            var adm1 = new Administradora() { Nome = "ADM 1" };
            var adm2 = new Administradora() { Nome = "ADM 2" };
            var adm3 = new Administradora() { Nome = "ADM 3" };

            context.Administradora.AddRange(new Administradora[] { adm1, adm2, adm3 });

            var cond1 = new Condominio() { Nome = "CONDO 1", Administradora = adm1 };
            var cond2 = new Condominio() { Nome = "CONDO 2", Administradora = adm2 };
            var cond3 = new Condominio() { Nome = "CONDO 3", Administradora = adm2 };

            context.Condominio.AddRange(new Condominio[] { cond1, cond2, cond3 });

            var usu1 = new Usuario() { Nome = "MORADOR", Email = "MORADOR@MORA.COM", Tipo = "MORADOR", CondominioNavigation = cond1 };
            var usu2 = new Usuario() { Nome = "SINDICO", Email = "SINDICO@MORA.COM", Tipo = "SINDICO", CondominioNavigation = cond2 };
            var usu3 = new Usuario() { Nome = "ADM", Email = "ADM@MORA.COM", Tipo = "ADM", CondominioNavigation = cond3 };

            context.Usuario.AddRange(new Usuario[] { usu1, usu2, usu3 });

            //

            context.SaveChanges();

            return context;
        }
    }
}
