using DomainModel.Services;


namespace Persistence.InMemory
{
    internal class GetProdottiByTestoLiberoPerCategoriaENome : IGetProdottiByTestoLiberoPerCategoriaENome
    {
        private readonly Database_hardcoded database;

        public GetProdottiByTestoLiberoPerCategoriaENome(Database_hardcoded database)
        {
            this.database = database;
        }
    } 
}
