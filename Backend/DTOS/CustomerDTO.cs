using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOS
{
    public class CustomerDTO
    {
        public int id { set; get; }
        public string Name { set; get; } 
        public string City { get; set; }
    }

}
