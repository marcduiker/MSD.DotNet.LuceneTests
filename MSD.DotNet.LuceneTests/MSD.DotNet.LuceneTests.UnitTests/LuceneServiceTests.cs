using NUnit.Framework;

namespace MSD.DotNet.Lucene.UnitTests
{
    [TestFixture]
    public class LuceneServiceTests
    {
        [Test]
        public void LuceneServiceConstructor_NewLuceneService_CreatesLuceneIndex()
        {
            // Arrange

            // Act
            var service = GetLuceneService();

            // Assert
            Assert.IsNotNull(service);
        }

        private LuceneService GetLuceneService()
        {
            return new LuceneService();
        }
    }
}
