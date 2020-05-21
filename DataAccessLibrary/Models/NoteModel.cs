using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DataAccess.Models
{
    public class NoteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userid")]
        public int? User { get; set; }

        [BsonElement("sectionid")]
        public int? Section { get; set; }

        [BsonElement("pageid")]
        public int? Page { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("dateofcreation")]
        public string DateOfCreation { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

    }
}
