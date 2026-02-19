using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace WebAPI.Model.Services
{
    public class ValidationErrors
    {
      
        public List<string> getValidationErrors(ModelStateDictionary _modelState) 
        {

            var errlist = new List<string>();

            foreach (var entry in _modelState)
            {
                string fieldName = entry.Key;
                var state = entry.Value;

                foreach (var error in state.Errors)
                {
                    
                    string errorMessage = error.ErrorMessage;
                    //Console.WriteLine($"Field: {fieldName}, Error: {errorMessage}");
                    errlist.Add($"Field: {fieldName}, Error: {errorMessage}");

                }
            }

            return errlist;

        }
    }
}
