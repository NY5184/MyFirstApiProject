//using System;
//using Entity;
//using System.Reflection.Metadata;
//using System.Text.Json;
//namespace IceCreamStoreRepostery
//{

//    public interface IIceCreamStoreReposteryUser
//    {


//        Task<User> addUserRegister(User newUser);

//        Task<User> getUserByUserNameAndPasswordLogin(UserLogin userLogin);

//        Task<User> UpdateUser(short id, User updatedUser);



//    }
//}
using System;
using Entity;
using System.Reflection.Metadata;
using System.Text.Json;
namespace IceCreamStoreRepostery
{

    public interface IIceCreamStoreReposteryUser
    {


        Task<User> addUserRegister(User newUser);

        Task<User> getUserByUserNameAndPasswordLogin(UserLogin userLogin);

        Task<User> UpdateUser(short id, User updatedUser);



    }
}