using System;
using System.Collections.Generic;

namespace DDonah.AthosDesafio.Domain
{
    public partial class Administradora
    {
        public Administradora()
        {
            Condominio = new HashSet<Condominio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Condominio> Condominio { get; set; }
    }
}