﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Burlaczenko.Raptor.Core
{
    public interface IResolver
    {
        object CreateInstance(XmlNode node);
    }
}
