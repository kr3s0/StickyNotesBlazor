using DataAccess.Models;
using DataAccessLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace DataAccess.BusinessLogic
{
    public class NoteData : INoteData
    {
        private readonly IMongoDBDataAccess _db;

        private readonly IMetaData _meta_db;

        public NoteData(IMongoDBDataAccess db,IMetaData metaData)
        {
            _db = db;
            _meta_db = metaData;
        }

        public async Task InsertNote(NoteModel note)
        {
            if (note.User is null)
            {
                Task<int> userid = _meta_db.GetFreeAndUpdateUserID();
            }
            if (note.Section is null)
            {
                Task<int> sectionid = _meta_db.GetFreeAndUpdateSectionID();
            }
            if (note.Page is null)
            {
                Task<int> pageid = _meta_db.GetFreeAndUpdatePageID();
            }
            if (note.User is null)
            {
                note.User = await _meta_db.GetFreeAndUpdateUserID();
            }
            if (note.Section is null)
            {
                note.Section = await _meta_db.GetFreeAndUpdateSectionID();
            }
            if (note.Page is null)
            {
                note.Page = await _meta_db.GetFreeAndUpdatePageID();
            }

            await this._db.InsertRecordToCollection<NoteModel>("notes", note);
        }

        public async Task DeleteNote(NoteModel note)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("pageid",note.Page);

            filter = filter & Builders<BsonDocument>.Filter.Eq("title", note.Title);

            filter = filter & Builders<BsonDocument>.Filter.Eq("content", note.Content);

            await this._db.DeleteRecordFromCollection<BsonDocument>("notes", filter);
        }

    }
}
