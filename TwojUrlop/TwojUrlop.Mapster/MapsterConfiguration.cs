using FastExpressionCompiler;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TwojUrlop.Mapster
{
    public class MapsterConfiguration : IMapsterConfiguration
    {
        public MapsterConfiguration()
        {
            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();
        }

        public MapsterConfiguration Scan()
        {
            List<Assembly> assemblies = new List<Assembly>();

            if (assemblies != null && assemblies.Count > 0)
            {
                Type baseType = typeof(IRegister);
                foreach (Assembly assembly in assemblies)
                {
                    List<Type> registers = assembly.GetTypes()
                        .Where(x => x != null && !x.IsAbstract && !x.IsInterface && baseType.IsAssignableFrom(x))
                        .ToList();
                    foreach (Type mpType in registers)
                    {
                        (Activator.CreateInstance(mpType) as IRegister).Register(TypeAdapterConfig.GlobalSettings);
                    }
                }
            }
            return this;
        }

        public MapsterConfiguration Compile()
        {
            TypeAdapterConfig.GlobalSettings.Compile();
            return this;
        }
    }
}
