using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using DataAccessLibrary.BusinessLogic;

namespace DataAccess.BusinessLogic
{
    public class SectionData : ISectionData
    {
        private readonly IMongoDBDataAccess _db;

        private readonly IMetaData _meta_db;

        public SectionData(IMongoDBDataAccess db,IMetaData meta)
        {
            _db = db;
            _meta_db = meta;
        }

        // TODO: Change every insert method to return Task<bool> if possible, so we know if action was successfull
        public async Task InsertSection(SectionModel section)
        {
            if (section.User is null)
            {
                Task<int> userid = _meta_db.GetFreeAndUpdateUserID(); 
            }
            if (section.Section is null)
            {
                Task<int> sectionid = _meta_db.GetFreeAndUpdateSectionID();
            }
            if (section.User is null)
            {
                section.User = await _meta_db.GetFreeAndUpdateUserID();
            }
            if (section.Section is null)
            {
                section.Section = await _meta_db.GetFreeAndUpdateSectionID();
            }

            await this._db.InsertRecordToCollection<SectionModel>("sections", section);
        }

        public Task<List<PageModel>> GetPagesForSection(SectionModel section)
        {
            var findBson = new BsonDocument { new BsonElement("sectionid", section.Section) };

            return this._db.LoadDocumentsFromCollection<PageModel>("pages", findBson);
        }

        public Task<List<PageModel>> GetPagesForSection(int sectionid)
        {
            var findBson = new BsonDocument { new BsonElement("sectionid", sectionid) };

            return this._db.LoadDocumentsFromCollection<PageModel>("pages", findBson);
        }

        public async Task DeleteSection(SectionModel section)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("sectionid", section.Section);

            //filter = filter & Builders<BsonDocument>.Filter.Eq("name", section.Name);

            var DeleteTask1 = this._db.DeleteRecordFromCollection<BsonDocument>("sections", filter);

            var DeleteTask2 = this._db.DeleteRecordFromCollection<BsonDocument>("pages", filter);

            var DeleteTask3 = this._db.DeleteRecordFromCollection<BsonDocument>("notes", filter);

            await Task.WhenAll(DeleteTask1, DeleteTask2, DeleteTask3);
        }

        public async Task DeleteSection(int sectionid)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("sectionid", sectionid);

            var DeleteTask1 = this._db.DeleteRecordFromCollection<BsonDocument>("sections", filter);
            
            var DeleteTask2 = this._db.DeleteRecordFromCollection<BsonDocument>("pages", filter);
            
            var DeleteTask3 = this._db.DeleteRecordFromCollection<BsonDocument>("notes", filter);

            await Task.WhenAll(DeleteTask1, DeleteTask2, DeleteTask3);
        }

    }
}
