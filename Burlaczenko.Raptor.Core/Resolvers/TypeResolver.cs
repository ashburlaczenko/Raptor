using System;
using System.Xml;
using Burlaczenko.Helpers;
using Burlaczenko.Raptor.Core.Exceptions;

namespace Burlaczenko.Raptor.Core.Resolvers
{
    public class TypeResolver : ITypeResolver
    {
        public Type GetType( XmlNode node)
        {
            var type = node.Name.ToSystemType();

            if (type == null)
            {
                throw new UnsupportedTypeException();
            }

            return type;
        }
    }
}
