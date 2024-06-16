using Domain.Common.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels
{
    public class ProducerViewModel
    {
        [Required]
        [MaxLength(126, ErrorMessage = "Name can't be more than 126 characters")]
        public string Name { get; set; }
        [MaxLength(620, ErrorMessage = "Bio can't be more than 620 characters")]
        public string Bio { get; set; }
        //[DobValidation(ErrorMessage = "Producer cant be younger than 12 years")]
        public DateTime DateofBirth { get; set; }
        [Required]
        [MaxLength(126, ErrorMessage = "Company can't be more than 126 characters")]
        public string Company { get; set; }
        [Required]
        [MaxLength(26, ErrorMessage = "Gender can't be more than 26 characters")]
        public string Gender { get; set; }
    }
}
