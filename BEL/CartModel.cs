using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CartModel
    {
        public int Id { get; set; }
        public Nullable<int> Product_Id { get; set; }
        public Nullable<System.DateTime> Created_At { get; set; }
        public Nullable<System.DateTime> Modified_At { get; set; }
        public Nullable<int> Buyer_Id { get; set; }

    }
}
