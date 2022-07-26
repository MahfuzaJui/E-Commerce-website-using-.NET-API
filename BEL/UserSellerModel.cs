using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class UserSellerModel : userModel
    {
        public sellerModel seller { get; set; }
        public UserSellerModel()
        {
            seller = new sellerModel();
        }
    }
    
}
