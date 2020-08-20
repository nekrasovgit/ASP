using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DNekrasovDB.ModelView
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required faild")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required faild")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
