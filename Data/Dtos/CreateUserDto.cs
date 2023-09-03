﻿using System.ComponentModel.DataAnnotations;

namespace SenorBarbero.Data.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
        public string? ConfirmPassword { get; set;}
    }
}
