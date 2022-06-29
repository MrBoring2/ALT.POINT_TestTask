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
using ClientsAPI.Models.Validation;

namespace ClientsAPI.Models.Errors
{
    public partial class ValidationError : Error
    {
        public ValidationError(List<ValidationExceptions> exceptions)
        {
            Exceptions = exceptions;
        }

        [Range(422, 422)]
        public new int Status { get; private set; } = 422;
        public new string Code { get; private set; } = "VALIDATION_EXCEPTION";
        public List<ValidationExceptions> Exceptions { get; private set; }
    }
}