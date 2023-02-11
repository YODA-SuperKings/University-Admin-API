using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class CollegeRegistrationService : ICollegeRegistrationService
    {
        private readonly IMongoCollection<CollegeRegistration> _CollegeRegCollection;
        public CollegeRegistrationService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _CollegeRegCollection = mongoDatabase.GetCollection<CollegeRegistration>("CollegeRegistration");
        }
        public List<CollegeRegistration> GetCollegeRegistration()
        {
            List<CollegeRegistration> CollegeRegistration;
            CollegeRegistration = _CollegeRegCollection.Find(colg => true).ToList();
            return CollegeRegistration;
        }
        public string CreateCollegeRegistration(CollegeRegistration _CollegeRegistration)
        {
            string msg = "";
            _CollegeRegCollection.InsertOne(_CollegeRegistration);

            return msg;
        }
    }
}
