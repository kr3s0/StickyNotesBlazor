using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IMongoDBDataAccess
    {
        string ConnectionStringName { get; set; }

        Task InsertRecordToCollection<T>(string Collection, T record);
        Task<List<T>> LoadDocumentsFromCollection<T>(string collection, BsonDocument bdoc);

        Task UpdateRecordInCollection<T>(string collection, FilterDefinition<T> filter, UpdateDefinition<T> update);

        Task DeleteRecordFromCollection<T>(string collection, FilterDefinition<T> filter);
    }
}