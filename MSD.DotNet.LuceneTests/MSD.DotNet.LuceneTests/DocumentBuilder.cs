using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Lucene.Net.Documents;

namespace MSD.DotNet.Lucene
{
    public class DocumentBuilder
    {
        private const string ID_ATTRIBUTE = "id";
        private const string ENTRY_ELEMENT = "entry";
        private const string MESSAGE_ELEMENT = "message";
        List<Document> _documentCollection = new List<Document>();
        Document _document;

        public List<Document> BuildFromXml(string path)
        {
            if (!File.Exists(path))
            {
                return _documentCollection;
            }

            using (XmlReader reader = XmlReader.Create(path))
            {
                var dictionary = new Dictionary<string, Action>{
                        { ENTRY_ELEMENT,() => CreateDocument(reader) },
                        { MESSAGE_ELEMENT, () => AddMessageToDocument(reader) }
                };

                while (reader.Read())
                {
                    string key = reader.Name;
                    if (reader.NodeType == XmlNodeType.Element && dictionary.ContainsKey(key))
                    {
                        dictionary[key].Invoke();
                    }
                }
            }

            return _documentCollection;
        }

        private void CreateDocument(XmlReader reader)
        {
            _document = new Document();
            _document.Add(FieldFactory.CreateStoredAndUnindexedField(ID_ATTRIBUTE, reader.GetAttribute(ID_ATTRIBUTE)));
        }

        private void AddMessageToDocument(XmlReader reader)
        {
            if (_document != null)
            {
                _document.Add(FieldFactory.CreateStoredAndIndexedField(MESSAGE_ELEMENT, reader.ReadInnerXml()));

                // Add the document to the collection after the final Field has been added.
                _documentCollection.Add(_document);
                _document = null;
            }
        }
    }
}
