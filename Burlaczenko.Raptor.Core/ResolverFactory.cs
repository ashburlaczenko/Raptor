using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Burlaczenko.Raptor.Core.Resolvers;

namespace Burlaczenko.Raptor.Core
{
    public class ResolverFactory : IResolverFactory
    {
        public IResolver GetResolver(Type type)
        {
            if (type == typeof (string))
            {
                return new StringResolver();
            }

            if (type == typeof(bool))
            {
                return new BooleanResolver();
            }

            if (type == typeof(int))
            {
                return new IntegerResolver();
            }
            
            return new DefaultResolver();
        }

        public ITypeResolver GetInterfaceResolver()
        {
            return new TypeResolver();
        }
    }
}
