using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.BusinessLogic
{
    public interface IPageData
    {
        Task<List<NoteModel>> GetNotesForPage(PageModel page);

        Task<List<NoteModel>> GetNotesForPage(int pageid);

        Task InsertPage(PageModel page);
        
        Task DeletePage(PageModel page);
        
        Task DeletePage(int pageid);
    }
}