using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Unesi Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Unesi Password")]
        public string Password { get; set; }
    }
}
