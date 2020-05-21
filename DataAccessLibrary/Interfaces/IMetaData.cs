using System.Threading.Tasks;

namespace DataAccessLibrary.BusinessLogic
{
    public interface IMetaData
    {
        Task<int> GetFreeAndUpdatePageID();

        Task<int> GetFreeAndUpdateSectionID();

        Task<int> GetFreeAndUpdateUserID();

        Task<int> GetNumberOfBsonsInCollection(string collection, int userid);
    }
}