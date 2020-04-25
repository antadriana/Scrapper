

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GraphQLService.Entities
{
    public class Info
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        // string wide_name;
        public string price { get; set; }
        public string change { get; set; }
        public string perentage_changed { get; set; }
        //  Type type;

        public Info(string name, string price, string change, string percent_change)
        {
            this.name = name;
            // this.wide_name = wide_name;
            this.price = price;
            this.change = change;
            this.perentage_changed = percent_change;
        }
        public Info() {; }
    }
}
