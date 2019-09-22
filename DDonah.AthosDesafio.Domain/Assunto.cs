using System;
using System.Collections.Generic;

namespace DDonah.AthosDesafio.Domain
{
    public partial class Assunto
    {
        public Assunto()
        {
            Mensagem = new HashSet<Mensagem>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Mensagem> Mensagem { get; set; }
    }
}