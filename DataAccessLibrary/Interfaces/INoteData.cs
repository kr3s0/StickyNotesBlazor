using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.BusinessLogic
{
    public interface INoteData
    {
        Task InsertNote(NoteModel note);

        Task DeleteNote(NoteModel note);

    }
}