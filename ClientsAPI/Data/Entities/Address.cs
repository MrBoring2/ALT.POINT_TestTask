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
    public partial class Address : BaseEntity
    { 
        public Address()
        {
            if (Id == Guid.Empty)
            {
                this.Id = Guid.NewGuid();
            }
            if(CreatedAt == DateTime.MinValue)
            {
                CreatedAt = DateTime.Now;
                UpdatedAt = CreatedAt;
            }
        }
        public Guid Id { get; private set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

    }
}
