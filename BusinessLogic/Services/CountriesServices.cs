using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly IMongoCollection<Country> _countriesCollection;
        public CountriesService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _countriesCollection = mongoDatabase.GetCollection<Country>("Countries");
        }
        public List<Country> GetCountries()
        {
            List<Country> countries;
            countries = _countriesCollection.Find(c => true).ToList();
            return countries;
        }
    }
}
