using MongoDB.Bson.Serialization.Attributes;


namespace FiskeNettet.Entities.Models
{
    public class Coordinates
    {
        [BsonElement("lat")]
        public double Lat { get; set; }
        [BsonElement("long")]
        public double Lng { get; set; }
    }
}
