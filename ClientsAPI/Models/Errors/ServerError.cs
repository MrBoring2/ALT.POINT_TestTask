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
    public partial class ServerError : Error
    {
        public ServerError(int status)
        {
            Status = status;
        }

        [Range(500, 599)]
        public new int Status { get; private set; }
        public new string Code { get; private set; } = "INTERNAL_SERVER_ERROR";
    }
}