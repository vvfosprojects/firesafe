using DomainModel.Classes;

namespace DomainModel.Services
{
    public interface IGetProdottoByCodice
    {
        Prodotto Get(string codice);
    }
}
