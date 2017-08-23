using SimpleInjector;
using SimpleInjector.Lifestyles;
using Stone.Imobilizado.Repository;
using Stone.Imobilizado.Service;

namespace Stone.Imobilizado.IOC
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            //Registrando as Implementações
            container.Register<IImobilizadoRepository, ImobilizadoRepository>();
            container.Register<IImobilizadoService, ImobilizadoService>();
            

            container.Verify();
            return container;
        }
    }
}
