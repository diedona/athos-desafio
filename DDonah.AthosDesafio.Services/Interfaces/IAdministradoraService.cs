using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDonah.AthosDesafio.Services
{
    public interface IAdministradoraService : IBaseService<Administradora>
    {
        Administradora GetByNome(string nome);
    }
}
