using BEL;
using DAL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class requestService
    {
        public static bool AddRequest(requestModel obj)
        {
            bool flag = false;
            var r = new request();
            r.postid = obj.postid;
            r.userid = obj.userid;
            r.bidprice = obj.bidprice;
            r.status = "pending";
            r.mark = "unread";
            r.date = DateTime.Now;
            flag = DataAccessFactory.Request().Add(r);
            return flag;
        }

        public static bool DeleteRequest(int id)
        {
            bool flag = false;
            flag = DataAccessFactory.Request().Delete(id);
            return flag;
        }
        public static bool EditRequest(requestModel obj)
        {
            var r = new request();
            r.id = obj.id;
            r.postid = obj.postid;
            r.userid = obj.userid;
            r.bidprice = obj.bidprice;
            r.status = obj.status;
            r.mark = obj.mark;
            r.date = obj.date;
            var flag = DataAccessFactory.Request().Edit(r);
            return flag;
        }

        public static List<requestModel> AllRequest()
        {
            var data = DataAccessFactory.Request().Get();
            var reqList = new List<requestModel>();
            foreach(var d in data)
            {
                var r = new requestModel();
                r.id = d.id;
                r.postid = d.postid;
                r.userid = d.userid;
                r.bidprice = d.bidprice;
                r.status = d.status;
                r.mark = d.mark;
                r.date = d.date;
                reqList.Add(r);
            }
            return reqList;
        }
    }
}
