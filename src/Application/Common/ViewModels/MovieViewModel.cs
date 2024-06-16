using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels
{
    public class MovieViewModel
    {
        [Required]
        [MaxLength(126, ErrorMessage = "Gender can't be more than 126 characters")]
        public string Name { get; set; }
        [MaxLength(620, ErrorMessage = "Plot can't be more than 620 characters")]
        public string Plot { get; set; }
        [Required]
        public DateTime DateofRelease { get; set; }
        public string Poster { get; set; }
        [Required]
        public string Producer { get; set; }
        public List<string> Actors { get; set; }
    }
}
