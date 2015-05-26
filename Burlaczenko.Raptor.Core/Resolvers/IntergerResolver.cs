using System;
using System.Xml;
using Burlaczenko.Helpers;
using Burlaczenko.Raptor.Core.Exceptions;

namespace Burlaczenko.Raptor.Core.Resolvers
{
    public class IntegerResolver : IResolver
    {
        public object CreateInstance(XmlNode node)
        {
            var value = node.GetAttribute<int>("value");

            if (value == null)
            {
                throw new ElementConfigurationException();
            }

            return value;
        }
    }
}
