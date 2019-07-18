using System;
using SimpleInjector;

namespace CompositionRoot
{
    /// <summary>
    ///   This class contains all the custom application bindings.
    /// </summary>
    internal static class CustomBindings
    {
        internal static void Bind(Container container)
        {
            //BindDB_InMemory(container);
            BindDB_MongoDb(container);
        }

        private static void BindDB_MongoDb(Container container)
        {
            container.Register<DomainModel.Services.IGetProdottoByCodice, Persistence.MongoDB.GetProdottoByCodice>();

            container.Register<DomainModel.Services.IGetProdottiByTestoLibero, Persistence.MongoDB.GetProdottiByTestoLibero>();

            container.Register<Persistence.MongoDB.DbContext>(() =>
            {
                return new Persistence.MongoDB.DbContext(@"mongodb://localhost:27017/firesafe");
            }, Lifestyle.Singleton);
        }

        private static void BindDB_InMemory(Container container)
        {
            container.Register<DomainModel.Services.IGetProdottoByCodice, Persistence.InMemory.GetProdottoByCodice>();

            container.Register<DomainModel.Services.IGetProdottiByTestoLibero, Persistence.InMemory.GetProdottiByTestoLibero>();

            container.Register<Persistence.InMemory.Database>(Lifestyle.Singleton);
        }
    }
}
