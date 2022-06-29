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

namespace ClientsAPI.Data.Entities
{ 
    public partial class Passport : BaseEntity
    {
        public Passport()
        {
            if(Id == Guid.Empty)
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
        public string Series { get; set; }    
        public string Number { get; set; }     
        public string Giver { get; set; }     
        public DateTime DateIssued { get; set; }     
        public DateTime CreatedAt { get; private set; }       
        public DateTime UpdatedAt { get; private set; }
    }
}
