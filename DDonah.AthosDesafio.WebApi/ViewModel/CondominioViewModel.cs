using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDonah.AthosDesafio.WebApi.ViewModel
{
    public class CondominioViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int AdministradoraId { get; set; }
        public int? UsuarioSindicoId { get; set; }
        public int? UsuarioZeladorId { get; set; }


        public string AdministradoraNome { get; set; }
        public string UsuarioSindicoNome { get; set; }
        public string UsuarioZeladorNome { get; set; }
    }
}
