using Funder.Models;
using Funder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Funder.Services
{
  public interface IUserManager
    {
        User CreateUser(UserOption usrOption);       
        User Update(UserOption usrOption, int userId);
        User FindUserByEmail(UserOption userOption);
    }                                                      
}
