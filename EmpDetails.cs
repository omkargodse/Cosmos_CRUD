using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_CRUD
{
    public class EmpDetails
    {
        public Guid id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
    }
}
