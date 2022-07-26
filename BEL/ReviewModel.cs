using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ReviewModel
    {
        public int id { get; set; }
        public int Buyer_Id { get; set; }
        public double Rating { get; set; }
        public string Review1 { get; set; }
    }
}
