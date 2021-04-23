using FiskeNettet.Entities.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace FiskeNettet.Models
{
    public class FishingSpot
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("fishTypes")]
        public List<string> FishTypes { get; set; }

        [BsonElement("gps")]
        public Coordinates Gps { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }
    }
}