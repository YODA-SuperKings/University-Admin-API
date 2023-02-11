using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IMongoCollection<Document> _DocumentCollection;
        public DocumentService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _DocumentCollection = mongoDatabase.GetCollection<Document>("Document");
        }
        public List<Document> GetDocument()
        {
            List<Document> document;
            document = _DocumentCollection.Find(emp => true).ToList();
            return document;
        }

        public string CreateDocument(Document document)
        {
            string msg = "";
            _DocumentCollection.InsertOne(document);

            return msg;
        }
    }
}
