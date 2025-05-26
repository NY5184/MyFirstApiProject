
using Entity;
using IceCreamStoreRepostery;
using Zxcvbn;
using System.Linq;


namespace IceCreamStoreService
{
    public class IceCreamStoreServiceUser : IIceCreamStoreServiceUser
    {
        IIceCreamStoreReposteryUser _repostery;
        public IceCreamStoreServiceUser(IIceCreamStoreReposteryUser repostery)
        {
            _repostery = repostery;
        }



        public async Task<User> addUserRegister(User newUser)
        {
            if (!validPassword(newUser.Password))
            {
                throw new ArgumentException("you nead to enter a good password");
            }
            return await _repostery.addUserRegister(newUser);

        }

        public bool validPassword(string password)
        {

            var result = Zxcvbn.Core.EvaluatePassword(password);
            int score = result.Score;
            if ((score) < 2)
                return false;
            return true;

        }

        public async Task<User> getUserByUserNameAndPasswordLogin(UserLogin userLogin)
        {

            User theLoggedInUser = await _repostery.getUserByUserNameAndPasswordLogin(userLogin);
            if (theLoggedInUser == null)
            {
                throw new KeyNotFoundException("User not found with the provided username and password.");
            }


            return theLoggedInUser;

        }

        public async Task<User> UpdateUser(short id, User updatedUser)
        {
            if (!validPassword(updatedUser.Password))
            {
                throw new ArgumentException("you nead to enter a good password");
            }
            User theUpdatedUser = await _repostery.UpdateUser(id, updatedUser);
            if (theUpdatedUser == null)
            {
                throw new KeyNotFoundException("you are not logged in");
            }
            return theUpdatedUser;
        }


    }
}