using Lucene.Net.Documents;

namespace MSD.DotNet.Lucene
{
    public static class FieldFactory
    {
        public static Field CreateUnstoredAndUnindexedField(string name, string value)
        {
            return new Field(name, value, Field.Store.NO, Field.Index.NO);
        }

        public static Field CreateStoredAndIndexedField(string name, string value)
        {
            return new Field(name, value, Field.Store.YES, Field.Index.ANALYZED);
        }

        public static Field CreateUnstoredAndIndexedField(string name, string value)
        {
            return new Field(name, value, Field.Store.NO, Field.Index.ANALYZED);
        }

        public static Field CreateStoredAndUnindexedField(string name, string value)
        {
            return new Field(name, value, Field.Store.YES, Field.Index.NO);
        }
    }
}
