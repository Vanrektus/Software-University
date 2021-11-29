using System;

namespace CustomDI.Contracts
{
    public interface IModule
    {
        //---------------------------Methods---------------------------
        void Configure();

        Type GetMapping(Type currentInterfacee, object attribute);

        object GetInstance(Type type);

        void SetInstance(Type implementation, object instance);
    }
}
