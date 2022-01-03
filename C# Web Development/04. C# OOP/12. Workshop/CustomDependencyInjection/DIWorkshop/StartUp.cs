using DIWorkshop.Core;
using DIWorkshop.Infrastructure;
using CustomDI;
using CustomDI.Injectors;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace DIWorkshop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //IServiceProvider serviceProvider = DependancyResolver.GetServiceProvider();
            //IEngine engine = serviceProvider.GetService<IEngine>();

            Injector injector = DependancyInjector.CreateInjector(new Module());
            Engine engine = injector.Inject<Engine>();

            engine.Run();
        }
    }
}
