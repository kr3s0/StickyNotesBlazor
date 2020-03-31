using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;

namespace StickyNotesBlazor.Models
{
    public class DisplayNoteModel
    {
        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(40, ErrorMessage = "Title is too long.")]
        [MinLength(1, ErrorMessage = "Tittle is too short.")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Date not in correct format.")]
        [MinLength(1, ErrorMessage = "Date not in correct format")]
        public string DateOfCreation { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(500, ErrorMessage = "Details are too big.")]
        public string Details { get; set; }

        public NoteModel GetDatabaseModel(int userid, int sectionid,int pageid)
        {
            return new NoteModel
            {
                User = userid,
                Section = sectionid,
                Page = pageid,
                Title = this.Name,
                Content = this.Details,
                DateOfCreation = this.DateOfCreation
            };
        }
    }
}
