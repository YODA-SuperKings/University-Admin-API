using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _studentCollection;
        public StudentService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _studentCollection = mongoDatabase.GetCollection<Student>("Student");
        }
        public List<Student> GetStudent()
        {
            List<Student> student;
            student = _studentCollection.Find(student => true).ToList();
            return student;
        }

        public string CreateStudent(Student student)
        {
            string msg = "";
            _studentCollection.InsertOne(student);

            return msg;
        }
    }
}
