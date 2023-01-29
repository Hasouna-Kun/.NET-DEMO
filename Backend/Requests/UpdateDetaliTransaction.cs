using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Requests
{
    public class UpdateDetaliTransaction
    {
        public int CategoryId { get; set; }
        public DateTime RetrievalDate { get; set; }
        public int TransactionId { get; set; }
        public decimal Price { get; set; }
    }
}
