using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
    public class PageModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userid")]
        public int? User { get; set; }

        [BsonElement("sectionid")]
        public int? Section { get; set; }

        [BsonElement("pageid")]
        public int? Page { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("details")]
        public string Details { get; set; }

        [BsonElement("dateofcreation")]
        public string DateOfCreation { get; set; }
    }
}
