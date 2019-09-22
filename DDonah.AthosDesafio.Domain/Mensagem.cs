using System;
using System.Collections.Generic;

namespace DDonah.AthosDesafio.Domain
{
    public partial class Mensagem
    {
        public int Id { get; set; }
        public int AssuntoId { get; set; }
        public int UsuarioEmissorId { get; set; }
        public int? UsuarioResponsavelId { get; set; }
        public int? AdministradoraResponsavelId { get; set; }
        public string Texto { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Administradora AdministradoraResponsavel { get; set; }
        public virtual Assunto Assunto { get; set; }
        public virtual Usuario UsuarioEmissor { get; set; }
        public virtual Usuario UsuarioResponsavel { get; set; }
    }
}