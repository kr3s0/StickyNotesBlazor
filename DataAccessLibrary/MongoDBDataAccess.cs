using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MongoDBDataAccess : IMongoDBDataAccess
    {
        private readonly IConfiguration _config;

        private IMongoDatabase _db;

        private readonly string DatabaseName = "stickynotes";

        public string ConnectionStringName { get; set; } = "default";

        public readonly string ConnectionString;

        public MongoDBDataAccess(IConfiguration config)
        {
            _config = config;

            this.ConnectionString = this._config.GetConnectionString(this.ConnectionStringName);

            this._db = new MongoClient(this.ConnectionString).GetDatabase(this.DatabaseName);
        }

        //Retrieve all documents from collection
        public async Task<List<T>> LoadDocumentsFromCollection<T>(string collection, BsonDocument bdoc)
        {
            var dbColl = this._db.GetCollection<T>(collection);

            var data = await dbColl.FindAsync(bdoc);

            return data.ToList();
        }

        public async Task InsertRecordToCollection<T>(string Collection, T record)
        {
            var dbColl = this._db.GetCollection<T>(Collection);

            await dbColl.InsertOneAsync(record);
        }

        public async Task UpdateRecordInCollection<T>(string collection, FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            var dbColl = this._db.GetCollection<T>(collection);

            await dbColl.UpdateOneAsync(filter, update);
        }

        public async Task DeleteRecordFromCollection<T>(string collection, FilterDefinition<T> filter)
        {
            var dbColl = this._db.GetCollection<T>(collection);

            await dbColl.DeleteOneAsync(filter);
        }

    }
}
