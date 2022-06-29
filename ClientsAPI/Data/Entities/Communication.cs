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
    public partial class Communication : BaseEntity
    {
        public Communication()
        {
            if (Id == Guid.Empty)
            {
                this.Id = Guid.NewGuid();
            }
        }
        public Guid Id { get; private set; }
       
        public CommunicationTypeEnum Type { get; set; }
        public string Value { get; set; }
    }
}
