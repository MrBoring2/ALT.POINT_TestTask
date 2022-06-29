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
    public partial class PaginationResponseBody<T> {
        public PaginationResponseBody(int limit, int page, int total, IEnumerable<T> data)
        {
            Limit = limit;
            Page = page;
            Total = total;
            Data = data;
        }

        public int Limit { get; set; }   
        public int Page { get; set; }       
        public int Total { get; set; }   
        public IEnumerable<T> Data { get; set; }       
    }
}