using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StickyNotesBlazor.Models
{
    public class DisplaySectionModel
    {
        // TODO: Correct these annotations, since we add them to webpage (Instead of "This filed" user "Name" i.e.)

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(20, ErrorMessage = "Title is too long.")]
        [MinLength(1, ErrorMessage = "Tittle is too short.")]
        public string Name { get; set; }

        [MaxLength(15, ErrorMessage = "Date not in correct format.")]
        [MinLength(1, ErrorMessage = "Date not in correct format.")]
        public string DateOfCreation { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(40, ErrorMessage = "Description is too big.")]
        public string Description { get; set; }

        public SectionModel GetDatabaseModel(int? userid=null)
        {
            return new SectionModel
            {
                User = userid,
                Section = null,
                Name = this.Name,
                Description = this.Description,
                DateOfCreation = this.DateOfCreation
            };
        }
    }
}
