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
            
            container.Register<IImobilizadoRepository, ImobilizadoRepository>();
            container.Register<IAndarRepository, AndarRepository>();

            container.Register<IImobilizadoService, ImobilizadoService>();
            container.Register<IAndarService, AndarService>();


            container.Verify();
            return container;
        }
    }
}
