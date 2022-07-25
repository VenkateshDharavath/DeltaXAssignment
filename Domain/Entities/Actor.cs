using Domain.Common.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Actor
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(126, ErrorMessage = "Gender can't be more than 126 characters")]
        public string Name { get; set; }
        [MaxLength(620, ErrorMessage = "Bio can't be more than 620 characters")]
        public string Bio { get; set; }
        [Required]
        //[DobValidation(ErrorMessage = "Actor cant be younger than 12 years")]
        public DateTime DateofBirth { get; set; }
        [Required]
        [GenderValidation(ErrorMessage = "Gender can only be either Male, Female, or Other (Case Sensitive)")]
        //[MaxLength(26, ErrorMessage = "Gender can't be more than 26 characterks")]
        public string Gender { get; set; }

    }
}
