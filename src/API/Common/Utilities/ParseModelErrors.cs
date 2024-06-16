using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Common.Utilities
{
    public static class ParseModelErrors
    {
        public static List<string> Parse(List<ModelErrorCollection> errors)
        {
            var strErrors = new List<string>();
            foreach(var error in errors)
            {
                foreach(var e in error.ToList())
                    strErrors.Add(e.ErrorMessage);
            }
            return strErrors;
        }
    }
}
