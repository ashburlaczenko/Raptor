using System;
using System.Xml;
using NUnit.Framework;

namespace Burlaczenko.Raptor.Core.Tests
{
    [TestFixture]
    public class ContructorTests
    {
        [Test]
        public void CanConstructContainerWithXmlDocument()
        {
            var xml = new XmlDocument();
            Assert.DoesNotThrow(() => { var container = new Container(xml); });
        }

        [Test]
        public void CanConstructContainerWithXmlString()
        {
            var xml = @"<container></container>";
            Assert.DoesNotThrow(() => { var container = new Container(xml); });
        }

        [Test]
        public void CannotConstructContainerWithValidXml()
        {
            var xml = @"<container>";
            Assert.Throws<XmlException>(() => { var container = new Container(xml); });
        }
    }
}
