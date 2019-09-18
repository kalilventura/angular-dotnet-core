using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API.Domain.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [MinLength(05)]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
