using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class requestModel
    {
        public int id { get; set; }
        public int postid { get; set; }
        public int userid { get; set; }
        public int bidprice { get; set; }
        public string status { get; set; }
        public string mark { get; set; }
        public System.DateTime date { get; set; }
    }
}
