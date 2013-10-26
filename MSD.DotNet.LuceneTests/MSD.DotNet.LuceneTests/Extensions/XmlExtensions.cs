using System;
using System.Xml;

namespace MSD.DotNet.Lucene.Extensions
{
    public static class XmlExtensions
    {
        public static bool IsElementOfName(
            this XmlReader reader,
            string elementName,
            StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return IsNodeTypeOfName(reader, XmlNodeType.Element, elementName, stringComparison);
        }

        public static bool IsAttributeOfName(
            this XmlReader reader,
            string attributeName,
            StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return IsNodeTypeOfName(reader, XmlNodeType.Attribute, attributeName, stringComparison);
        }

        private static bool IsNodeTypeOfName(
            XmlReader reader,
            XmlNodeType nodeType,
            string elementName,
            StringComparison stringComparison)
        {
            return reader.NodeType == nodeType
                && reader.Name.Equals(elementName, stringComparison);
        }
    }
}
