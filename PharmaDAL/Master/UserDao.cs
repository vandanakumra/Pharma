using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class UserDao : BaseDao
    {
        public UserDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public List<PharmaBusinessObjects.Master.UserMaster> GetUsers(string searchText)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.Users.Where(p=>p.Username.ToLower().Contains(searchText) || p.FirstName.ToLower().Contains(searchText) || p.LastName.ToLower().Contains(searchText)).Select(p => new PharmaBusinessObjects.Master.UserMaster()
                {
                    UserId = p.UserId,
                    Username = p.Username,
                    Password = p.Password,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    CreatedBy = p.CreatedBy,
                    CreatedOn = p.CreatedOn,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedOn = p.ModifiedOn,
                    Status = p.Status
                }).ToList();
            }
        }
        
        public PharmaBusinessObjects.Master.UserMaster GetUserByUserName(string userName)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.Users.Where(p=>p.Username == userName && p.Status).Select(p => new PharmaBusinessObjects.Master.UserMaster()
                {
                    UserId = p.UserId,
                    Username = p.Username,
                    Password = p.Password,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    CreatedBy = p.CreatedBy,
                    CreatedOn = p.CreatedOn,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedOn = p.ModifiedOn,
                    Status = p.Status
                }).FirstOrDefault();
            }
        }


        public PharmaBusinessObjects.Master.UserMaster GetUserByUserId(int userid)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.Users.Where(p => p.UserId == userid).Select(p => new PharmaBusinessObjects.Master.UserMaster()
                {
                    UserId = p.UserId,
                    Username = p.Username,
                    Password = p.Password,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    CreatedBy = p.CreatedBy,
                    CreatedOn = p.CreatedOn,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedOn = p.ModifiedOn,
                    Status = p.Status
                }).FirstOrDefault();
            }
        }

        public int AddUser(PharmaBusinessObjects.Master.UserMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                Entity.Users table = new Entity.Users()
                {
                    Username = p.Username,
                    Password = p.Password,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    CreatedBy = this.LoggedInUser.Username,
                    CreatedOn = System.DateTime.Now,                    
                    Status = p.Status
                };

                context.Users.Add(table);
                return context.SaveChanges();
            }
        }

        public int UpdateUser(PharmaBusinessObjects.Master.UserMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var user = context.Users.Where(q => q.UserId == p.UserId).FirstOrDefault();

                    if (user != null)
                    {
                        user.Password = p.Password;
                        user.Status = p.Status;
                        user.FirstName = p.FirstName;
                        user.LastName = p.LastName;
                        user.ModifiedBy =this.LoggedInUser.Username;
                        user.ModifiedOn = System.DateTime.Now;
                    }

                    return context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }



    }
}
