using System;
using System.Collections.Generic;

namespace DDonah.AthosDesafio.Domain
{
    public partial class Administradora
    {
        public Administradora()
        {
            Condominio = new HashSet<Condominio>();
            Mensagem = new HashSet<Mensagem>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Condominio> Condominio { get; set; }
        public virtual ICollection<Mensagem> Mensagem { get; set; }
    }
}