using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL
{
    public interface IAuth
    {

        Token Authenticate(string username, string password);
        bool IsAuthenticated(string token);
        bool IsBuyerAuthenticated(string token);
        bool Logout(int id);
    }
}
