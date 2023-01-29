using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Requests
{
    public class UpdateMasterTransaction
    {
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Discribe { get; set; }
        public List<UpdateDetaliTransaction> UpdateDetalis { set; get; }
    }
}
