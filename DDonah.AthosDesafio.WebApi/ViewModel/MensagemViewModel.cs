using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDonah.AthosDesafio.WebApi.ViewModel
{
    public class MensagemViewModel
    {
        public int Id { get; set; }
        public int AssuntoId { get; set; }
        public int UsuarioEmissorId { get; set; }
        public int? UsuarioResponsavelId { get; set; }
        public int? AdministradoraResponsavelId { get; set; }
        public string Texto { get; set; }
        public DateTime DateCreated { get; set; }

        public string AssuntoTipo { get; set; }
        public string UsuarioEmissorNome { get; set; }
        public string UsuarioResponsavelNome { get; set; }
        public string AdministradoraResponsavelNome { get; set; }

        public string EntidadeResponsavelNome => (this.UsuarioResponsavelId.HasValue) ? this.UsuarioResponsavelNome : this.AdministradoraResponsavelNome;
    }
}
