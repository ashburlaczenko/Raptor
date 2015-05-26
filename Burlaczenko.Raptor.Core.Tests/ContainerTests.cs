using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NUnit.Framework;

namespace Burlaczenko.Raptor.Core.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void CanResolveString()
        {
            const string xml = @"<configuration>
                                    <register>
                                        <string id=""1"" value=""test"" />
                                    </register>
                                </configuration>";
            var container = new Container(xml);

            var s = container.Resolve<string>("1");

            Assert.AreEqual("test", s);
        }

        [Test]
        public void CanResolveBoolean()
        {
            const string xml = @"<configuration>
                                    <register>
                                        <bool id=""1"" value=""true"" />
                                        <bool id=""2"" value=""false"" />
                                    </register>
                                </configuration>";
            var container = new Container(xml);

            Assert.AreEqual(true, container.Resolve<bool>("1"));
            Assert.AreEqual(false, container.Resolve<bool>("2"));
        }

        [Test]
        public void CanResolveInteger()
        {
            const string xml = @"<configuration>
                                    <register>
                                        <int id=""1"" value=""1"" />
                                        <int id=""2"" value=""20"" />
                                    </register>
                                </configuration>";
            var container = new Container(xml);

            Assert.AreEqual(1, container.Resolve<int>("1"));
            Assert.AreEqual(20, container.Resolve<int>("2"));
        }

        [Test]
        public void CanResolveCustomTypeWithIntegerProperty()
        {
            const string xml = @"<configuration>
                                    <register>
                                        <CustomType id=""1"" property=""100"" />
                                    </register>
                                </configuration>";
            var container = new Container(xml);

            Assert.AreEqual(100, container.Resolve<CustomType>("1").Property);
        }
    }
}
