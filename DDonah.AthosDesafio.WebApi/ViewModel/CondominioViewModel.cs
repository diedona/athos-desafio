using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDonah.AthosDesafio.WebApi.ViewModel
{
    public class CondominioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int AdministradoraId { get; set; }
        public int ResponsavelId { get; set; }
    }
}
