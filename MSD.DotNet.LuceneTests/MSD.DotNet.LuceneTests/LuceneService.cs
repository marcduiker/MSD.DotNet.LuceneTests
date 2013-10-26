using System;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;

namespace MSD.DotNet.Lucene
{
    public class LuceneService
    {
        private const string indexPath = @"c:\temp\LuceneIndex";
        private Directory luceneIndexDirectory;
        private IndexWriter indexWriter;
        private Analyzer analyzer;

        public LuceneService()
        {
            InitializeDirectory();
            InitializeAnalyzer();
            InitializeWriter();
        }

        private void InitializeDirectory()
        {
            if (System.IO.Directory.Exists(indexPath))
            {
                System.IO.Directory.Delete(indexPath, true);
            }

            luceneIndexDirectory = FSDirectory.Open(indexPath);
        }

        private void InitializeAnalyzer()
        {
            analyzer = new StandardAnalyzer(Version.LUCENE_30);
        }

        private void InitializeWriter()
        {
            indexWriter = new IndexWriter(luceneIndexDirectory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
        }

        public void Search(string query)
        {
            throw new NotImplementedException();
        }

        private Analyzer GetAnalyzer()
        {
            return new SimpleAnalyzer();
        }

        private IndexWriter GetIndexWriter(FSDirectory directory, Analyzer analyzer)
        {
            return new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
        }
    }
}
