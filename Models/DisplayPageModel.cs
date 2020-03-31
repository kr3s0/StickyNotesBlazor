using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StickyNotesBlazor.Models
{
    public class DisplayPageModel
    {
        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(20, ErrorMessage = "Title is too long.")]
        [MinLength(1, ErrorMessage = "Tittle is too short.")]
        public string Title { get; set; }

        [MaxLength(15, ErrorMessage = "Date not in correct format.")]
        [MinLength(1, ErrorMessage = "Date not in correct format")]
        public string DateOfCreation { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MinLength(1, ErrorMessage = "You cannot add empty note.")]
        public string Content { get; set; }

        public PageModel GetDatabaseModel(int userid,int sectionid)
        {
            return new PageModel
            {
                User = userid,
                Section = sectionid,
                Page = null,
                Name = this.Title,
                Details = this.Content,
                DateOfCreation = this.DateOfCreation
            };
        }
    }
}
