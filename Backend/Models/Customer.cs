using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? Phone { get; set; }
        public string City { get; set; }
    }
}
