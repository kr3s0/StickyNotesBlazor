using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StickyNotesBlazor.Models
{
    public class DisplayUserModel
    {
        [Required(ErrorMessage = "The username field is required!")]
        [StringLength(30, ErrorMessage = "Username must be between 3 and 30 characters", MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "The password field is required!")]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Password must be between 5 and 255 characters", MinimumLength = 5)]
        public string Password { get; set; }

        public UserModel GetDatabaseModel()
        {
            return new UserModel {
                User = null,
                Username = this.Username,
                Password = this.Password
            };
        }
    }
}
