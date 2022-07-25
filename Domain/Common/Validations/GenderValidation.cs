using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Validations
{
    public class GenderValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var genders = new List<string> { "Male", "Female", "Other" };
            string gender = Convert.ToString(value);
            foreach(var gen in genders) { if (gender == gen.Trim()) return true; }

            return false;
        }
    }
}
