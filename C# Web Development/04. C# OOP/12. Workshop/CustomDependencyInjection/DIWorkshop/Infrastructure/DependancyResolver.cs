using DIWorkshop.Contracts;
using DIWorkshop.Core;
using DIWorkshop.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIWorkshop.Infrastructure
{
    public static class DependancyResolver
    {
        //---------------------------Methods---------------------------
        public static IServiceProvider GetServiceProvider()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection
                .AddTransient<IReader, ConsoleReader>()
                .AddTransient<IConsoleWriter, ConsoleWriter>()
                .AddTransient<IFileWriter, FileWriter>()
                .AddTransient<IEngine, Engine>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
