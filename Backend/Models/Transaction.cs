using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Discribe { get; set; }
    }
}
