using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ClientsAPI.Models.Validation
{ 
    public partial class ValidationExceptions
    {
        public ValidationExceptions(string field, string rule, string message)
        {
            Field = field;
            Rule = rule;
            Message = message;
        }

        public string Field { get; private set; }      
        public string Rule { get; private set; }       
        public string Message { get; private set; }      
    }
}
