using System;
using System.Collections.Generic;

namespace DDonah.AthosDesafio.Domain
{
    public partial class Condominio
    {
        public Condominio()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int AdministradoraId { get; set; }
        public int? ResponsavelId { get; set; }

        public virtual Administradora Administradora { get; set; }
        public virtual Usuario Responsavel { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}