using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.BusinessLogic
{
    public interface IUserData
    {
        Task<List<SectionModel>> GetSectionsForUser(UserModel user);

        Task<List<SectionModel>> GetSectionsForUser(int userid);

        Task<bool> InsertUser(UserModel user);

        Task<int> UserLogIn(UserModel user);
    }
}