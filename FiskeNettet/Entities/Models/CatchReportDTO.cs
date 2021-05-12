using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Entities.Models
{
    public class CatchReportDTO
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("fishType")]
        public string FishType { get; set; }

        [BsonElement("length")]
        [AllowNull]
        public double Length { get; set; }

        [BsonElement("weight")]
        [AllowNull]
        public double Weight { get; set; }

        [BsonElement("gps")]
        public Coordinates Gps { get; set; }

        [BsonElement("image")]
        public string Image { get; set; }
    }
}