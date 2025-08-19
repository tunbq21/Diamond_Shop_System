using DSS_SWP.Models;
using DSS_SWP.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService
    {
        private UserRepo _repo = new UserRepo();
        public UserService()
        {
            
        }
        public User GetAccount(string email, string password)
        {
            return _repo.GetAccount(email,password);
        }
    }


}
