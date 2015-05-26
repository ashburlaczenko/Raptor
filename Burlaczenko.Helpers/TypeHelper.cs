using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Burlaczenko.Helpers
{
    public static class TypeHelper
    {
        public static Dictionary<string, Type> SystemTypes = new Dictionary<string, Type>
        {
            { "string", typeof(string) },
            { "bool", typeof(bool) },
            { "int", typeof(int) },
        };

        public static Type ToSystemType(this string @this)
        {
            if (@this == null)
            {
                return null;
            }

            var type = SystemTypes.ContainsKey(@this) ? SystemTypes[@this] : null;
            return type;
        }
    }
}
