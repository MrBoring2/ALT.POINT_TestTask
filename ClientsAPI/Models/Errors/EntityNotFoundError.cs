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

namespace ClientsAPI.Models.Errors
{
    public partial class EntityNotFoundError : Error
    {

        [Range(404, 404)]
        public new int Status { get; private set; } = 404;
        public new string Code { get; private set; } = "ENTITY_NOT_FOUND";
    }
}