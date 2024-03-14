using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;

namespace Workspace.CodeBase.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetNonGenericInheritedTypes(this Type type)
        {
            IEnumerable<Type> types = type.Assembly.GetTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericTypeDefinition)
                .Where(x => x.ImplementsOrInherits(type));

            return types;
        }
        
    }
}