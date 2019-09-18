﻿using CompanyAPI.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Domain.ViewModel
{
    public class UserViewModel
    {
        public Email Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
