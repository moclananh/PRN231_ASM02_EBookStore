using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class UserDAO
    {
        public static User Login(string emailAddress, string password)
        {
            User user = null;
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    // Find user by email and verify password
                    user = context.Users.SingleOrDefault(u => u.EmailAddress == emailAddress && u.Password == password);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }


        public static User Register(User newUser)
        {
            try
            {
                using (var context = new Prn231Asm2EBookStoreContext())
                {
                    // Check if the email is already registered
                    var existingUser = context.Users.SingleOrDefault(u => u.EmailAddress == newUser.EmailAddress);
                    if (existingUser != null)
                    {
                        throw new Exception("Email is already registered.");
                    }

                    // Add the new user to the database
                    context.Users.Add(newUser);
                    context.SaveChanges();

                    // Return the newly created user
                    return newUser;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
