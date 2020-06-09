using Funder.Models;
using Funder.Options;
using Funder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Funder.Services
{
    public class UserManagement : IUserManager
    {
        private FunderDbContext db;

        public UserManagement(FunderDbContext _db)
        {
            db = _db;
        }


        //CRUD
        // create read update delete
        public User CreateUser(UserOption usrOption)
        {
            User user = new User
            {
                FirstName = usrOption.FirstName,
                LastName = usrOption.LastName,
                Email = usrOption.Email
              
                

            };


            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }


        public User Update(UserOption usrOption, int userId)
        {

            User user = db.Users.Find(userId);

            if (usrOption.FirstName != null)
                user.FirstName = usrOption.FirstName;
            if (usrOption.LastName != null)
                user.LastName = usrOption.LastName;
            if (usrOption.Email != null)
                user.Email = usrOption.Email;
            if (usrOption.Dob != new DateTime())
                user.Dob = usrOption.Dob;

            db.SaveChanges();
            return user;
        }

       

        public User FindUserByEmail(UserOption userOption)
        {
            if (userOption == null) return null;
            if (userOption.Email == null) return null;

            return db.Users
                .Where(user => user.Email == userOption.Email)
                .FirstOrDefault();
        }
    }
}
   

       