using System.Collections.Generic;
using System.IO;
using System.Xml;
using Lucene.Net.Documents;
using MSD.DotNet.Lucene.Extensions;

namespace MSD.DotNet.Lucene
{
    public class DocumentBuilder
    {
        public List<Document> BuildFromXml(string path)
        {
            List<Document> documentCollection = new List<Document>();

            if (!File.Exists(path))
            {
                return documentCollection;
            }

            using (XmlReader reader = XmlReader.Create(path))
            {
                const string ID_ATTRIBUTE = "id";
                const string ENTRY_ELEMENT = "entry";
                const string MESSAGE_ELEMENT = "message";
                Document document = null;

                while (reader.Read())
                {
                    if (reader.IsElementOfName(ENTRY_ELEMENT))
                    {
                        // Once an entry is found a new Document needs to be created.
                        document = new Document();
                        document.Add(FieldFactory.CreateStoredAndUnindexedField(ID_ATTRIBUTE, reader.GetAttribute(ID_ATTRIBUTE)));
                    }

                    // TODO: Add more fields

                    if (reader.IsElementOfName(MESSAGE_ELEMENT) && document != null)
                    {
                        document.Add(FieldFactory.CreateStoredAndIndexedField(MESSAGE_ELEMENT, reader.ReadInnerXml()));

                        // Add the document to the collection after the final Field has been added.
                        documentCollection.Add(document);
                    }
                }
            }

            return documentCollection;
        }


    }
}
