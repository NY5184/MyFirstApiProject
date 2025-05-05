using System;
using Entity;
using System.Reflection.Metadata;
using System.Text.Json;
namespace IceCreamStoreRepostery
{

    public interface IIceCreamStoreReposteryUser
    {


         User addUserRegister(User newUser);

         User getUserByUserNameAndPasswordLogin(UserLogin userLogin);

         User UpdateUser(int id, User updatedUser);



    }
}
