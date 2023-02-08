using System;
using System.Collections.Generic;
using System.Text;
using Model = BusinessLogic.Model.Services.Users;

namespace BusinessLogic.Interface.Services.Users
{
    public interface IUsersService
    {
        List<Model::Users> GetUsers();
        string CreateUser(Model::Users user);
    }
}
