using CustomDI.Contracts;
using CustomDI.Injectors;

namespace CustomDI
{
    public static class DependancyInjector
    {
        //---------------------------Methods---------------------------
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();

            return new Injector(module);
        }
    }
}
