using System;
using System.Xml;

namespace Burlaczenko.Raptor.Core.Resolvers
{
    public class DefaultResolver : IResolver
    {
        public object CreateInstance(XmlNode node)
        {
            return null;
        }
    }
}
