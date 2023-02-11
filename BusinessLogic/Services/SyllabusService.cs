﻿using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class SyllabusService : ISyllabusService
    {
        private readonly IMongoCollection<Syllabus> _syllabusCollection;
        public SyllabusService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _syllabusCollection = mongoDatabase.GetCollection<Syllabus>("Syllabus");
        }
        public List<Syllabus> GetSyllabus()
        {
            List<Syllabus> syllabus;
            syllabus = _syllabusCollection.Find(syl => true).ToList();
            return syllabus;
        }

        public string CreateSyllabus(Syllabus syllabus)
        {

            string msg = "";
            _syllabusCollection.InsertOne(syllabus);

            return msg;
        }
    }
}
