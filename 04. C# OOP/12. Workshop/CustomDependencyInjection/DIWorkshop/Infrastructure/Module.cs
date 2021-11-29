using CustomDI.Modules;
using DIWorkshop.Contracts;
using DIWorkshop.Core;
using DIWorkshop.Services;

namespace DIWorkshop.Infrastructure
{
    public class Module : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
            CreateMapping<IWriter, FileWriter>();
            CreateMapping<IEngine, Engine>();
        }
    }
}
