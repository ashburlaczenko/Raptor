using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burlaczenko.Raptor.Core
{
    public class RegisteredInstance
    {
        public string Id { get; set; }

        public Type Type { get; set; }

        public object Value { get; set; }

        public RegisteredInstance(string id, Type type, object instance)
        {
            this.Id = id;
            this.Type = type;
            this.Value = instance;
        }

        public bool Is<T>()
        {
            return this.Type == typeof (T);
        }

        public T OfType<T>()
        {
            return (T) this.Value;
        }
    }
}
