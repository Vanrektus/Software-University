using CustomDI.Attributes;
using CustomDI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDI.Modules
{
    public abstract class AbstractModule : IModule
    {
        //---------------------------Fields---------------------------
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        //---------------------------Constructors---------------------------
        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        //---------------------------Methods---------------------------
        public abstract void Configure();

        protected void CreateMapping<TInter, TImpl>()
        {
            Type interfaceType = typeof(TInter);
            Type implementationType = typeof(TImpl);

            if (!this.implementations.ContainsKey(interfaceType))
            {
                this.implementations.Add(interfaceType, new Dictionary<string, Type>());
                //this.implementations[interfaceType] = new Dictionary<string, Type>();
            }

            this.implementations[interfaceType].Add(implementationType.Name, implementationType);
        }

        public object GetInstance(Type type)
        {
            this.instances.TryGetValue(type, out object value);

            return value;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            Type result = null;

            var currentImplementations = this.implementations[currentInterface];

            if (currentImplementations == null || currentImplementations.Count == 0)
            {
                throw new ArgumentException($"No implementation found for type {currentInterface.Name}");
            }

            if (attribute is InjectAttribute)
            {
                result = currentImplementations
                    .Values
                    .FirstOrDefault();
            }
            else if (attribute is NamedAttribute named)
            {
                result = currentImplementations[named.Name];
            }

            return result;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }
    }
}
