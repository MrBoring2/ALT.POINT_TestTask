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
    public partial class Child : BaseEntity
    {
        public Child()
        {
            if (Id == Guid.Empty)
            {
                this.Id = Guid.NewGuid();
            }
        }
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Dob { get; set; }
        [JsonIgnore]
        public List<Client> Parents { get; set; }
    }
}
