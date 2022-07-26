using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PropertyType { get; set; }
        public Nullable<int> Bed { get; set; }
        public Nullable<int> Bath { get; set; }
        public Nullable<double> Size { get; set; }
    }
}
