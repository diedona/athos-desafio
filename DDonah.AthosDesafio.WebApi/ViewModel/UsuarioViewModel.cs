using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDonah.AthosDesafio.WebApi.ViewModel
{
    public class UsuarioViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int CondominioId { get; set; }
        public string Tipo { get; set; }

        public string CondominioNome { get; set; }
    }
}
