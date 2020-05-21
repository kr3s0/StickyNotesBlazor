using DataAccess;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccessLibrary.BusinessLogic
{
    public class MetaData : IMetaData
    {
        private readonly IMongoDBDataAccess _db;

        public MetaData(IMongoDBDataAccess db)
        {
            _db = db;
        }

        public async Task<int> GetFreeAndUpdateUserID()
        {
            BsonDocument bson = new BsonDocument { new BsonElement("name", "metadata") };

            List<MetadataModel> meta = await this._db.LoadDocumentsFromCollection<MetadataModel>("metadata", bson);

            var result = meta[0].User;

            meta[0].User++;

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("name","metadata");

            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("freeuserid",meta[0].User);

            await _db.UpdateRecordInCollection<BsonDocument>("metadata",filter,update);

            return result;

        }

        public async Task<int> GetFreeAndUpdateSectionID()
        {
            BsonDocument bson = new BsonDocument { new BsonElement("name", "metadata") };

            List<MetadataModel> meta = await this._db.LoadDocumentsFromCollection<MetadataModel>("metadata", bson);

            var result = meta[0].Section;

            meta[0].Section++;

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("name", "metadata");

            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("freesectionid", meta[0].Section);

            await _db.UpdateRecordInCollection<BsonDocument>("metadata", filter, update);

            return result;

        }

        public async Task<int> GetFreeAndUpdatePageID()
        {
            BsonDocument bson = new BsonDocument { new BsonElement("name", "metadata") };

            List<MetadataModel> meta = await this._db.LoadDocumentsFromCollection<MetadataModel>("metadata", bson);

            var result = meta[0].Page;

            meta[0].Page++;

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("name", "metadata");

            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("freepageid", meta[0].Page);

            await _db.UpdateRecordInCollection<BsonDocument>("metadata", filter, update);

            return result;

        }

        public async Task<int> GetNumberOfBsonsInCollection(string collection,int userid)
        {
            BsonDocument bson = new BsonDocument { new BsonElement("userid", userid) };

            List<BsonDocument> docs = await this._db.LoadDocumentsFromCollection<BsonDocument>(collection, bson);

            return docs.Count();
        }

    }
}
