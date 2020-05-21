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
    public class PageData : IPageData
    {
        private readonly IMongoDBDataAccess _db;

        private readonly IMetaData _meta_db;

        public PageData(IMongoDBDataAccess db,IMetaData meta)
        {
            _db = db;
            _meta_db = meta;
        }

        public async Task InsertPage(PageModel page)
        {
            if (page.User is null)
            {
                Task<int> userid = _meta_db.GetFreeAndUpdateUserID();
            }
            if (page.Section is null)
            {
                Task<int> sectionid = _meta_db.GetFreeAndUpdateSectionID();
            }
            if (page.Page is null)
            {
                Task<int> pageid = _meta_db.GetFreeAndUpdatePageID();
            }
            if (page.User is null)
            {
                page.User = await _meta_db.GetFreeAndUpdateUserID();
            }
            if (page.Section is null)
            {
                page.Section = await _meta_db.GetFreeAndUpdateSectionID();
            }
            if (page.Page is null)
            {
                page.Page = await _meta_db.GetFreeAndUpdatePageID();
            }

            await this._db.InsertRecordToCollection<PageModel>("pages", page);
        }

        public Task<List<NoteModel>> GetNotesForPage(PageModel page)
        {
            var findBson = new BsonDocument { new BsonElement("pageid", page.Page) };

            return this._db.LoadDocumentsFromCollection<NoteModel>("notes", findBson);
        }

        public Task<List<NoteModel>> GetNotesForPage(int pageid)
        {
            var findBson = new BsonDocument { new BsonElement("pageid", pageid) };

            return this._db.LoadDocumentsFromCollection<NoteModel>("notes", findBson);
        }

        public async Task DeletePage(PageModel page)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("pageid",page.Page);

            var DeleteTask1 = this._db.DeleteRecordFromCollection("pages", filter);
            
            var DeleteTask2 = this._db.DeleteRecordFromCollection("notes", filter);

            await Task.WhenAll(DeleteTask1, DeleteTask2);
        }

        public async Task DeletePage(int pageid)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("pageid", pageid);

            var DeleteTask1 = this._db.DeleteRecordFromCollection("pages", filter);

            var DeleteTask2 = this._db.DeleteRecordFromCollection("notes", filter);

            await Task.WhenAll(DeleteTask1, DeleteTask2);
        }
    }
}
