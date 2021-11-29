using System;

namespace CustomDI.Contracts
{
    public interface IModule
    {
        void Configure();

        Type GetMapping(Type currentInterfacee, object attribute);

        object GetInstance(Type type);

        void SetInstance(Type implementation, object instance);
    }
}
