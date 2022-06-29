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
    public partial class Error 
    { 
        [Range(400, 599)]
        public int Status { get; set; }     
        public string Code { get; set; }            
    }
}
