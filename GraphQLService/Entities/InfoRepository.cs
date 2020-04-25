using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLService.Entities
{
    public static class InfoRepository
    {
        static InfoService inf;
        static DatabaseSettings dbSet = new DatabaseSettings
        {
            CollectionName = "News",
            DatabaseName = "News",
            ConnectionString = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false"
        };
        static InfoRepository()
        {
            inf = new InfoService(dbSet);
        }

       public static List<Info> GetAll()
        {
            return inf.Get();
        }

        public static Info AddInfo(Info i)
        {

            return inf.Create(i);
            // inf.Get();
        }
    }
}
