using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Burlaczenko.Helpers;
using Burlaczenko.Raptor.Core.Exceptions;

namespace Burlaczenko.Raptor.Core
{
    public class Container
    {
        public XmlDocument Xml { get; set; }

        private List<RegisteredInstance> registered;

        private IResolverFactory resolverFactory;

        public Container()
        {
            this.Xml = new XmlDocument();
            this.Initialise();
        }

        public Container(XmlDocument xml)
        {
            this.Xml = xml;
            this.Initialise();
        }

        public Container(string xml)
        {
            this.Xml = new XmlDocument();
            this.Xml.LoadXml(xml);
            this.Initialise();
        }

        public void Register<T>(string id, T value)
        {
            var instance = new RegisteredInstance(id, value.GetType(), value);
            this.registered.Add(instance);
        }

        public T Resolve<T>(string id)
        {
            var instance = registered.Where(x => x.Is<T>()).FirstOrDefault(x => x.Id == id);
            return instance == null ? default(T) : instance.OfType<T>();
        }

        private void Register(XmlNode node)
        {
            foreach (XmlNode xmlNode in node.ChildNodes)
            {
                this.Register(xmlNode);
            }

            if (node.Name != "register")
            {
                var instance = this.ResolveInstance(node);
                this.Register(node.GetAttribute<string>("id"), instance);
            }
        }

        private object ResolveInstance(XmlNode node)
        {
            var resolver = this.resolverFactory.GetInterfaceResolver();
            var @type = resolver.GetType(node);

            return this.ResolveInstance(@type, node);
        }

        private object ResolveInstance(Type type, XmlNode node)
        {
            var resolver = this.resolverFactory.GetResolver(@type);
            return  resolver.CreateInstance(node);
        }

        private void ParseXml()
        {
            var nodes = this.Xml.SelectNodesOrDefault("//register");
            foreach (var node in nodes)
            {
                this.Register(node);
            }
        }

        private void Initialise()
        {
            this.registered = new List<RegisteredInstance>();
            this.resolverFactory = new ResolverFactory();
            this.ParseXml();
        }
    }
}
