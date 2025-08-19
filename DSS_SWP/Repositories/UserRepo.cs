using DSS_SWP.BaseDAO;
using DSS_SWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS_SWP.Repositories
{
    public class UserRepo : BaseDAO<User>
    {
        private DSS_CustomerContext _Context;
        public UserRepo()
        {
            
        }

        public User GetAccount(string email, string password)
        {
            _context = new DSS_CustomerContext();
            //&& (a.Role == 2 || a.Role == 1)
            return _context.Users.FirstOrDefault(a => a.Email == email && a.Password == password);
        }
    }
}
