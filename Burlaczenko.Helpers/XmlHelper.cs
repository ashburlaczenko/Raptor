using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Burlaczenko.Helpers
{
    public static class XmlHelper
    {
        public static IEnumerable<XmlNode> SelectNodesOrDefault(this XmlDocument @this, string selector)
        {
            if (string.IsNullOrEmpty(selector))
            {
                throw new ArgumentNullException();
            }

            var nodes = @this.SelectNodes(selector);
            return nodes != null ? nodes.OfType<XmlNode>() : new List<XmlNode>();
        }

        public static T GetAttribute<T>(this XmlNode @this, string name)
        {
            if (@this.Attributes == null)
            {
                return default(T);
            }

            foreach (XmlAttribute attribute in @this.Attributes)
            {
                if (attribute.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return (T)Convert.ChangeType(attribute.Value, typeof(T));
                }
            }

            return default(T);
        }
    }
}
