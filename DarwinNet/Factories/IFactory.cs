using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DarwinNet.Factories
{
    /// <summary>
    /// Defines an interface for Factories
    /// </summary>
    /// <typeparam name="T">The object that the factory will create</typeparam>
    internal interface IFactory<T>
    {
        public T Create(XmlDocument response);
    }
}
