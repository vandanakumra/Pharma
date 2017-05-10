using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class UserBiz : BaseBiz
    {
        public UserBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal List<PharmaBusinessObjects.Master.UserMaster> GetUsers()
        {
            return new PharmaDAL.Master.UserDao(this.LoggedInUser).GetUsers();
        }

        internal PharmaBusinessObjects.Master.UserMaster GetUserByUserName(string userName)
        {
            return new PharmaDAL.Master.UserDao(this.LoggedInUser).GetUserByUserName(userName);
        }

        internal PharmaBusinessObjects.Master.UserMaster GetUserByUserId(int userid)
        {
            return new PharmaDAL.Master.UserDao(this.LoggedInUser).GetUserByUserId(userid);
        }

        internal int AddUser(PharmaBusinessObjects.Master.UserMaster p)
        {
            return new PharmaDAL.Master.UserDao(this.LoggedInUser).AddUser(p);
        }

        internal int UpdateUser(PharmaBusinessObjects.Master.UserMaster p)
        {
            return new PharmaDAL.Master.UserDao(this.LoggedInUser).UpdateUser(p);
        }


    }
}
