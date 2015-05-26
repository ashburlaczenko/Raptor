using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burlaczenko.Raptor.Core
{
    public interface IResolverFactory
    {
        IResolver GetResolver(Type type);

        ITypeResolver GetInterfaceResolver();
    }
}
