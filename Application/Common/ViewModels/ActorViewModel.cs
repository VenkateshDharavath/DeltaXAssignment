using Domain.Common.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels
{
    public class ActorViewModel
    {
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
