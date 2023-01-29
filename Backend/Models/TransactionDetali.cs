using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class TransactionDetali
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime RetrievalDate { get; set; }
        public int TransactionId { get; set; }
        public decimal Price { get; set; }
    }
}
