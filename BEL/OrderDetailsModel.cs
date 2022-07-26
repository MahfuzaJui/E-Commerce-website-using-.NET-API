using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public Nullable<double> Cart_Id { get; set; }
        public Nullable<double> Total { get; set; }
        public string Status { get; set; }
    }
}
