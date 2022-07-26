using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class SellModel
    {
        public int Id { get; set; }
        public Nullable<int> Product_Id { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<System.DateTime> AvailableFrom { get; set; }
    }
}
