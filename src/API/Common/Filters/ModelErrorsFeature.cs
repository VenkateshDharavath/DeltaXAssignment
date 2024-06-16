using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Common.Filters
{
    public class ModelErrorsFeature
    {
        public List<ModelErrorCollection> Errors { get; set; }

        public ModelErrorsFeature(List<ModelErrorCollection> errorList)
        {
            this.Errors = errorList;
        }
    }
}
