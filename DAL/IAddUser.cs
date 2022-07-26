using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAddUser<T>
    {
        int AddUser(T e);
    }
}
