using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lucene.Net.Documents;
using NUnit.Framework;

namespace MSD.DotNet.Lucene.UnitTests
{
    [TestFixture]
    public class DocumentBuilderTests
    {
        [Test]
        public void Build_Document_ReturnsDocument()
        {
            // Arrange
            var builder = GetDocumentBuilder();
            var xmlInput = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.xml");

            // Act
            List<Document> documentCollection = builder.BuildFromXml(xmlInput);

            // Assert
            Assert.IsTrue(documentCollection.Any());
        }

        private DocumentBuilder GetDocumentBuilder()
        {
            return new DocumentBuilder();
        }
    }
}
