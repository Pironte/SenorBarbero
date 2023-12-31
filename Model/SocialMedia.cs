﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SenorBarbero.Enums.GlobalEnums;

namespace SenorBarbero.Model
{
    [Table("RedeSocial")]
    public class SocialMedia
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column("Rede")]
        public SocialNetwork SocialNetwork { get; set; }
    }
}
