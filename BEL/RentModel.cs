using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class RentModel
    {
        public int Id { get; set; }
        public Nullable<int> Product_Id { get; set; }
        public Nullable<double> Rate { get; set; }
        public Nullable<System.DateTime> Available_From { get; set; }
        public Nullable<double> Advance_Amount { get; set; }
    }
}
