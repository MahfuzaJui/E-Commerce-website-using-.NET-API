using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class UserBuyerModel: userModel
    {
        public buyerModel buyer { get; set; }

        public UserBuyerModel()
        {
            buyer = new buyerModel();
        }
    }
}
