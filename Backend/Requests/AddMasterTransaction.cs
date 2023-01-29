using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Requests
{
    public class AddMasterTransaction
    {
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Discribe { get; set; }
        public List<AddDetalisTransaction> addDetalis { set; get; }
    }
}
