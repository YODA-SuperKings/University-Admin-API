using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class ExaminationsService : IExaminationsService
    {
        private readonly IMongoCollection<Examinations> _ExaminationsCollection;
        public ExaminationsService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _ExaminationsCollection = mongoDatabase.GetCollection<Examinations>("Examinations");
        }
        public List<Examinations> GetExaminations()
        {
            List<Examinations> examinations;
            examinations = _ExaminationsCollection.Find(emp => true).ToList();
            return examinations;
        }

        public string CreateExaminations(Examinations examinations)
        {
            string msg = "";
            _ExaminationsCollection.InsertOne(examinations);

            return msg;
        }
    }
}
