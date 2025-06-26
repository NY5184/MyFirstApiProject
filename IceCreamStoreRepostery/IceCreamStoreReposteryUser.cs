
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
        public async Task<User> AddUserRegister(User newUser) // Change to PascalCase: AddUserRegister
        {
            await _WebApiContext.Users.AddAsync(newUser);
            await _WebApiContext.SaveChangesAsync();
            return newUser;
        }
        public async Task<User> GetUserByUserNameAndPasswordLogin(UserLogin userLogin) // Change to PascalCase: GetUserByUserNameAndPasswordLogin
        {
            return await _WebApiContext.Users.SingleAsync(u => u.UserName == userLogin.userName && userLogin.password == u.Password);//change to FirstOrDefaultAsync
            //SingleAsync - זורק שגיאה אם לא מצא 
            //FirstOrDefaultAsync - לא זורק שגיאה במקרה שלא מצא 
        }


        public async Task<User> UpdateUser(int id, User updatedUser)//UpdateUser(User updatedUser)
        {
            // var userToUpdate = await _WebApiContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            // if (userToUpdate == null)
            // {
            //     return null;
            // }
            // userToUpdate.FirstName = updatedUser.FirstName;
            // userToUpdate.LastName = updatedUser.LastName;
            // userToUpdate.UserName = updatedUser.UserName;
            // userToUpdate.Password = updatedUser.Password;
            _WebApiContext.Update(updatedUser);
            await _WebApiContext.SaveChangesAsync();
            return userToUpdate;
        }


    }
}