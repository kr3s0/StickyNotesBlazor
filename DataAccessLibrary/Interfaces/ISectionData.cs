using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.BusinessLogic
{
    public interface ISectionData
    {
        Task<List<PageModel>> GetPagesForSection(SectionModel section);

        Task<List<PageModel>> GetPagesForSection(int pageid);

        Task InsertSection(SectionModel section);

        Task DeleteSection(SectionModel section);

        Task DeleteSection(int sectionid);
    }
}