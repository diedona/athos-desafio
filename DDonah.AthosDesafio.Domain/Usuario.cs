﻿using System;
using System.Collections.Generic;

namespace DDonah.AthosDesafio.Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            Condominio = new HashSet<Condominio>();
            MensagemUsuarioEmissor = new HashSet<Mensagem>();
            MensagemUsuarioResponsavel = new HashSet<Mensagem>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int CondominioId { get; set; }
        public string Tipo { get; set; }

        public virtual Condominio CondominioNavigation { get; set; }
        public virtual ICollection<Condominio> Condominio { get; set; }
        public virtual ICollection<Mensagem> MensagemUsuarioEmissor { get; set; }
        public virtual ICollection<Mensagem> MensagemUsuarioResponsavel { get; set; }
    }
}