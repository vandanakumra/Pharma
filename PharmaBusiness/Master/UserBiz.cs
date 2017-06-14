using PharmaDAL.Master;
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

        internal List<PharmaBusinessObjects.Master.UserMaster> GetUsers(string searchText)
        {
            return new PharmaDAL.Master.UserDao(this.LoggedInUser).GetUsers(searchText);
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

        public List<PharmaBusinessObjects.Master.Role> GetRoles(string searchText)
        {
            return new UserDao(this.LoggedInUser).GetRoles(searchText);
        }

        public List<PharmaBusinessObjects.Master.Role> GetActiveRoles()
        {
            List<PharmaBusinessObjects.Master.Role> roles = new UserDao(this.LoggedInUser).GetRoles(string.Empty);
            return roles.Where(p => p.Status).ToList();
        }

        public PharmaBusinessObjects.Master.Role GetRoleById(int userid)
        {
            return new UserDao(this.LoggedInUser).GetRoleById(userid);
        }

        public bool AddRole(PharmaBusinessObjects.Master.Role p)
        {
            return new UserDao(this.LoggedInUser).AddRole(p);
        }

        public bool UpdateRole(PharmaBusinessObjects.Master.Role p)
        {
            return new UserDao(this.LoggedInUser).UpdateRole(p);
        }

        public List<PharmaBusinessObjects.Master.Privledge> GetPrivledges(string searchText)
        {
            return new UserDao(this.LoggedInUser).GetPrivledges(searchText);
        }

        public List<PharmaBusinessObjects.Master.Privledge> GetActivePrivledges()
        {
            return new UserDao(this.LoggedInUser).GetPrivledges(string.Empty).Where(p => p.Status).ToList();
        }

        public PharmaBusinessObjects.Master.Privledge GetPrivledgeById(int userid)
        {
            return new UserDao(this.LoggedInUser).GetPrivledgeById(userid);
        }

        public bool AddPrivledge(PharmaBusinessObjects.Master.Privledge p)
        {
            return new UserDao(this.LoggedInUser).AddPrivledge(p);
        }

        public bool UpdatePrivledge(PharmaBusinessObjects.Master.Privledge p)
        {
            return new UserDao(this.LoggedInUser).UpdatePrivledges(p);
        }

        public PharmaBusinessObjects.Master.UserMaster ValidateUser(string userName, string password)
        {
            return new UserDao(this.LoggedInUser).ValidateUser(userName, password);
        }

    } 
}
