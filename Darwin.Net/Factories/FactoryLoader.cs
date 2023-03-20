using Darwin.Net.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Darwin.Net.Factories
{
    /// <summary>
    /// Defines a factory loader, allowing a generic factory to be able to load data into a generic object.
    /// </summary>
    internal static class FactoryLoader
    {
        /// <summary>
        /// Loads data from an <see cref="XmlDocument"/> into <typeparamref name="T"/> using it's <paramref name="factory"/>
        /// </summary>
        /// <typeparam name="T">The type of object that will be created</typeparam>
        /// <param name="factory">The <see cref="IFactory{T}"/> being used to create the object</param>
        /// <param name="doc">An <see cref="XmlDocument"/> containing data to be added to the object</param>
        /// <returns></returns>
        public static T LoadFromXml<T>(IFactory<T> factory, XmlDocument doc)
        {
            // Clear all namespaces to allow deserialisation
            ClearXmlNamespaces(doc);
            return factory.Create(doc);
        }

        /// <summary>
        /// Converts an <see cref="XmlNode"/> object to an object of type T using the specified factory.
        /// </summary>
        /// <typeparam name="T">The type of object to create.</typeparam>
        /// <param name="factory">The factory object used to create the object of type T.</param>
        /// <param name="ele">The <see cref="XmlNode"/> object to convert.</param>
        /// <returns>An object of type T created from the specified <see cref="XmlNode"/>.</returns>
        public static T XmlElementToT<T>(IFactory<T> factory, XmlNode ele)
        {
            var doc = new XmlDocument();
            doc.AppendChild(doc.ImportNode(ele, true));
            return LoadFromXml(factory, doc);
        }

        /// <summary>
        /// Clears all namespace declarations from an <see cref="XmlDocument"/> object.
        /// </summary>
        /// <param name="doc">The <see cref="XmlDocument"/> object to remove namespace declarations from.</param>
        private static void ClearXmlNamespaces(XmlDocument doc)
        {
            // Select all elements that have a namespace URI
            var nodes = doc.SelectNodes("//*[namespace-uri()!='']");

            // Check if any matching nodes were found
            if (nodes == null) return;

            // Iterate over each matching node and replace it with a new element without a prefix
            foreach (XmlElement node in nodes)
            {
                // Get the new local name of the element (without the prefix)
                var newName = node.LocalName;

                // Create a new element with the new name and attributes
                var newElement = node.OwnerDocument.CreateElement(newName);
                foreach (XmlAttribute attr in node.Attributes)
                {
                    newElement.SetAttribute(attr.LocalName, attr.Value);
                }

                // Move all child nodes to the new element
                while (node.HasChildNodes)
                {
                    newElement.AppendChild(node.FirstChild);
                }

                // Replace the old element with the new element
                node.ParentNode.ReplaceChild(newElement, node);
            }

            // Remove all namespace declarations from the document
            var xmlnsAttrs = doc.SelectNodes("//@*[namespace-uri()='http://www.w3.org/2000/xmlns/']");
            if (xmlnsAttrs == null) return;

            // Iterate over each namespace declaration and remove it from the document
            foreach (XmlAttribute attr in xmlnsAttrs)
            {
                attr.OwnerElement?.RemoveAttribute(attr.Name);
            }
        }

    }
}
