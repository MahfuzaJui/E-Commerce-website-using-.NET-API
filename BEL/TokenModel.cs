using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class TokenModel
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string B_Token { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime ExpiredAt { get; set; }
    }
}
