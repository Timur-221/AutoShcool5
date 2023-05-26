using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoShcool.MyClass;

namespace AutoShcool.DB
{
    public class MonD
    {

        private string connection = "mongodb://localhost:27017";
        private IMongoDatabase database;

        public bool CheckDataExists(string username, string password)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("AutoSchool");
            var collection = database.GetCollection<Account>("Admin"); 

            var filter = Builders<Account>.Filter.Eq(x => x.AdLogin, username) & Builders<Account>.Filter.Eq(x => x.AdPassword, password);
            var user = collection.Find(filter).FirstOrDefault();

            return user != null;
        }

        public void AddUser(UserInfo userInfo)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("AutoSchool"); 
            var collection = database.GetCollection<UserInfo>("Student"); 
            collection.InsertOne(userInfo);
        }

        public bool CheckStudentExists(string username, string password)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("AutoSchool"); 
            var collection = database.GetCollection<UserInfo>("Student"); 

            var filter1 = Builders<UserInfo>.Filter.Eq(x => x.Login, username) & Builders<UserInfo>.Filter.Eq(x => x.Password, password);
            var user = collection.Find(filter1).FirstOrDefault();

            return user != null;
        }

        
    }
}
