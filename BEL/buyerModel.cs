using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class buyerModel
    {
        public int id { get; set; }
        public int uid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string occupation { get; set; }
        public Nullable<int> netincome { get; set; }
    }
}
