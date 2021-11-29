using CustomDI.Attributes;
using CustomDI.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CustomDI.Injectors
{
    public class Injector
    {
        //---------------------------Fields---------------------------
        private IModule module;

        //---------------------------Constructors---------------------------
        public Injector(IModule module)
        {
            this.module = module;
        }

        //---------------------------Methods---------------------------
        public T Inject<T>()
        {
            bool hasConstructorInjection = CheckForConstructorInjection<T>();
            bool hasFieldInjection = CheckForFieldInjection<T>();

            if (hasConstructorInjection && hasFieldInjection)
            {
                throw new InvalidOperationException("Can use either Constructor or Field injection");
            }

            if (hasConstructorInjection)
            {
                return CreateConstructorInjection<T>();
            }

            if (hasFieldInjection)
            {
                return CreateFieldInjection<T>();
            }

            return default(T);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            Type desireClass = typeof(TClass);
            object desireClassInstance = this.module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this.module.SetInstance(desireClass, desireClassInstance);
            }

            var fields = desireClass.GetFields((BindingFlags)62);
            //var fields = desireClass.GetFields(
            //    BindingFlags.Public 
            //    | BindingFlags.NonPublic
            //    | BindingFlags.Instance
            //    | BindingFlags.Static);

            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.GetCustomAttributes(typeof(InjectAttribute), true).Any())
                {
                    InjectAttribute injection = (InjectAttribute)fieldInfo
                        .GetCustomAttributes(typeof(InjectAttribute), true)
                        .FirstOrDefault();
                    Type dependency = null;

                    NamedAttribute qualifier = fieldInfo
                        .GetCustomAttribute<NamedAttribute>(true);
                    Type type = fieldInfo.FieldType;

                    if (qualifier == null)
                    {
                        dependency = this.module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(type, qualifier);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this.module.SetInstance(dependency, instance);
                        }

                        fieldInfo.SetValue(desireClassInstance, instance);
                    }
                }
            }

            return (TClass)desireClassInstance;
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            Type desireClass = typeof(TClass);

            if (desireClass == null)
            {
                return default(TClass);
            }

            ConstructorInfo[] constructors = desireClass.GetConstructors();

            int i = 0;

            foreach (var constructorInfo in constructors)
            {
                if (!CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                object inject = constructorInfo
                    .GetCustomAttributes(typeof(InjectAttribute), true)
                    .FirstOrDefault();
                ParameterInfo[] parameterTypes = constructorInfo.GetParameters();
                object[] constructorParams = new object[parameterTypes.Length];

                foreach (var parameterInfo in parameterTypes)
                {
                    NamedAttribute named = parameterInfo.GetCustomAttribute<NamedAttribute>();
                    Type dependency = null;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(parameterInfo.ParameterType, inject);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(parameterInfo.ParameterType, named);
                    }

                    if (parameterInfo.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParams[i++] = instance;
                            this.module.SetInstance(parameterInfo.ParameterType, instance);
                        }
                        else
                        {
                            constructorParams[i++] = instance;
                        }
                    }
                }

                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }

            return default(TClass);
        }

        private bool CheckForFieldInjection<T>()
        {
            return typeof(T)
                .GetFields((BindingFlags)62)
                .Any(f => f.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private bool CheckForConstructorInjection<T>()
        {
            return typeof(T)
                .GetConstructors()
                .Any(c => c.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }
    }
}
