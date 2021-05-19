using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Entities.Models
{
    [BsonCollection("Indrapporteringer")]
    public class CatchReportDTO : Document
    {
        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("location_id")]
        [AllowNull]
        public string Location_Id { get; set; }

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