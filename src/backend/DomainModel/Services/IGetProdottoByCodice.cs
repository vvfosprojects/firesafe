using DomainModel.Classes;
using System.Collections.Generic;

namespace DomainModel.Services
{
    public interface IGetProdottoByCodice
    {
        Prodotto Get(string codice);
    }
}
