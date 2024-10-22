using BussinessObject.DataAccess;
using DataAccess.DAOs;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Login(string emailAddress, string password)
       => UserDAO.Login(emailAddress, password);

        public User Register(User user)
        => UserDAO.Register(user);
    }
}
