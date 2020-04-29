using GraphQLService.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLService
{
    public class InfoService
    {
            private readonly IMongoCollection<Info> _infos;

            public InfoService(IDatabaseSettings settings)
            {
                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.DatabaseName);

                _infos = database.GetCollection<Info>(settings.CollectionName);
            }

        public List<Info> Get()
        {
         var t =   _infos.Find(info => true).ToList();
            return t;
        }

        public Info GetById(string id) =>
           _infos.Find<Info>(info => info.id == id).FirstOrDefault();

        public Info Create(Info info)
        {
            _infos.InsertOne(info);
            return info;
        }

        public Info Update(string id, Info infoUpd)
        {
            _infos.ReplaceOne(info => info.id == id, infoUpd);
            return infoUpd;
        }
    }
}
