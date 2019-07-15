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
            container.Register<DomainModel.Services.IGetProdottoByCodice, Persistence.InMemory.GetProdottoByCodice>();

            container.Register<DomainModel.Services.IGetProdottiByTestoLibero, Persistence.InMemory.GetProdottiByTestoLibero>();

            container.Register<Persistence.InMemory.Database>(Lifestyle.Singleton);
        }
    }
}
