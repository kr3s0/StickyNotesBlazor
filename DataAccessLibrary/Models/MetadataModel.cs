using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class MetadataModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = "metadata";

        [BsonElement("freeuserid")]
        public int User { get; set; }

        [BsonElement("freesectionid")]
        public int Section { get; set; }

        [BsonElement("freepageid")]
        public int Page { get; set; }

    }
}
