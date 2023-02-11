using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.Services.Users;
using Model = BusinessLogic.Model.Services.Users;
using MongoDB.Driver;

namespace BusinessLogic.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IMongoCollection<Model::Users> _usersCollection;
        public UsersService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<Model::Users>("Users");
        }
        public List<Model::Users> GetUsers()
        {
            List<Model::Users> users;
            users = _usersCollection.Find(emp => true).ToList();
            return users;
        }

        public string CreateUser(Model::Users user)
        {
            string msg = "";
            bool isUserExists = _usersCollection.Find(usr => usr.Email == user.Email).Any() ? true : false;
            bool isNameExists = _usersCollection.Find(usr => usr.Name == user.Name).Any() ? true : false;
            if (isUserExists)
                msg = "User email already exists.";

            _usersCollection.InsertOne(user);
          
            return msg;
        }
    }
}
