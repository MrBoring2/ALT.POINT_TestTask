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
using ClientsAPI.Models.Enums;

namespace ClientsAPI.Data.Entities
{
    public partial class Job : BaseEntity
    {
        public Job()
        {
            if (Id == Guid.Empty)
            {
                this.Id = Guid.NewGuid();
            }
            if (CreatedAt == DateTime.MinValue)
            {
                CreatedAt = DateTime.Now;
                UpdatedAt = CreatedAt;
            }
        }
        public Guid Id { get; private set; }
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
       
        public JobTypeEnum Type { get; set; }
        public DateTime DateEmp { get; set; }
        public DateTime DateDismissal { get; set; }
        public decimal MonIncome { get; set; }
        public string Tin { get; set; }
        public Address FactAddress { get; set; } 
        public Address JurAddress { get; set; }
        public string PhoneNumber { get; set; }  
        public DateTime CreatedAt { get; private set; }    
        public DateTime UpdatedAt { get; private set; }     
    }
}