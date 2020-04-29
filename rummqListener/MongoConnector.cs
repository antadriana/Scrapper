using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace rummqListener
{
   public  class MongoConnector
    {
        MongoClient dbClient = new MongoClient();
        IMongoCollection<BsonDocument> collection;
        IMongoDatabase database;

        public MongoConnector()
        {
            var connectionString = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false";
            var client = new MongoClient(connectionString);
            database = client.GetDatabase("News");
            collection = database.GetCollection<BsonDocument>("News");
            Console.WriteLine("Mongo got db");
        }

        public void InsertDataToDB(string data)
        {
            List<Info> infos = JsonConvert.DeserializeObject<List<Info>>(data);

            foreach (var item in infos)
            {
                var document = new BsonDocument() {
                    { "name", item.name },
                    {"price", item.price },
                    {"change", item.change },
                    {"perentage_changed", item.percent_change },
                    {"like" ,false}
                };
                collection.InsertOne(document);
            }
          
            
               
      
        }
    }

}