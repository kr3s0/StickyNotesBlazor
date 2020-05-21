using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using DataAccessLibrary.BusinessLogic;

namespace DataAccess.BusinessLogic
{
    public class UserData : IUserData
    {
        private readonly IMongoDBDataAccess _db;

        private readonly IMetaData _meta_db;

        public UserData(IMongoDBDataAccess db,IMetaData meta)
        {
            this._db = db;
            _meta_db = meta;
        }

        public async Task<bool> InsertUser(UserModel user)
        {
            var findBson = new BsonDocument { new BsonElement("username", user.Username), new BsonElement("password", user.Password) };

            List<UserModel> temp = await this._db.LoadDocumentsFromCollection<UserModel>("users", findBson);

            if (temp.Count != 0)
            {
                return false;
            }

            if (user.User is null)
            {
                user.User = await _meta_db.GetFreeAndUpdateUserID();
            }

            await this._db.InsertRecordToCollection<UserModel>("users", user);

            return true;
        }

        public Task<List<SectionModel>> GetSectionsForUser(UserModel user)
        {
            var findBson = new BsonDocument { new BsonElement("userid", user.User) };

            return this._db.LoadDocumentsFromCollection<SectionModel>("sections", findBson);
        }

        public Task<List<SectionModel>> GetSectionsForUser(int userid)
        {
            var findBson = new BsonDocument { new BsonElement("userid", userid) };

            return this._db.LoadDocumentsFromCollection<SectionModel>("sections", findBson);
        }

        public async Task<int> UserLogIn(UserModel user)
        {
            var findBson = new BsonDocument { new BsonElement("username",user.Username), new BsonElement("password",user.Password) };

            List<UserModel> temp = await this._db.LoadDocumentsFromCollection<UserModel>("users",findBson);

            return temp.Count == 0 ? 0 : (int) temp[0].User;
        }
    }
}
