using System;
using System.Xml;
using Burlaczenko.Helpers;
using Burlaczenko.Raptor.Core.Exceptions;

namespace Burlaczenko.Raptor.Core.Resolvers
{
    public class BooleanResolver : IResolver
    {
        public object CreateInstance(XmlNode node)
        {
            var value = node.GetAttribute<bool>("value");

            if (value == null)
            {
                throw new ElementConfigurationException();
            }

            return value;
        }
    }
}
