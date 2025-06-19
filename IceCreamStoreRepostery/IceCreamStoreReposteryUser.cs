
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;



namespace IceCreamStoreRepostery
{
    public class IceCreamStoreReposteryUser : IIceCreamStoreReposteryUser
    {

        WebApiContext _WebApiContext;
        public IceCreamStoreReposteryUser(WebApiContext context)
        {
            _WebApiContext = context;
        }
        public async Task<User> addUserRegister(User newUser)
        {
            await _WebApiContext.Users.AddAsync(newUser);
            await _WebApiContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> getUserByUserNameAndPasswordLogin(UserLogin userLogin)
        {
            return await _WebApiContext.Users.SingleAsync(u => u.UserName == userLogin.userName && userLogin.password == u.Password);

        }


        public async Task<User> UpdateUser(int id, User updatedUser)
        {
            var userToUpdate = await _WebApiContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userToUpdate == null)
            {
                return null;
            }
            userToUpdate.FirstName = updatedUser.FirstName;
            userToUpdate.LastName = updatedUser.LastName;
            userToUpdate.UserName = updatedUser.UserName;
            userToUpdate.Password = updatedUser.Password;


            await _WebApiContext.SaveChangesAsync();
            return userToUpdate;


        }


    }
}