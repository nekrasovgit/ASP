using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.ModelView
{
    public class RegisterViewModel
    {
        

        [Required(ErrorMessage ="Email is required faild")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required faild")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password don't match")]
        [DataType(DataType.Password)]

        public string PasswordConfiguration { get; set; }
    }
}
