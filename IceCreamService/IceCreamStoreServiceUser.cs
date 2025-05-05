using Entity;
using IceCreamStoreRepostery;
using Zxcvbn;

namespace IceCreamStoreService
{
    public class IceCreamStoreServiceUser: IIceCreamStoreService
    {
        IIceCreamStoreReposteryUser repostery;


        public User addUserRegister(User newUser)
        {
            if(!validPassword(newUser.password))
            {
                throw new ArgumentException("you nead to enter a good password");
            }
            return repostery.addUserRegister(newUser);

        }

        public bool validPassword(string password)
        {

            var result = Zxcvbn.Core.EvaluatePassword(password);
            int score = result.Score;
            if ((score)<2)
            return false;
            return true;

        }

        public User getUserByUserNameAndPasswordLogin(UserLogin userLogin)
        {
            
            User theLoggedInUser = repostery.getUserByUserNameAndPasswordLogin(userLogin);
            if (theLoggedInUser == null)
            {
                throw new KeyNotFoundException("User not found with the provided username and password.");
            }

           
            return theLoggedInUser;

        }

        public User UpdateUser(int id,User updatedUser)
        {
            if (!validPassword(updatedUser.password))
            {
                throw new ArgumentException("you nead to enter a good password");
            }
            User theUpdatedUser=repostery.UpdateUser(id,updatedUser);
            if(theUpdatedUser==null)
            {
                throw new KeyNotFoundException("you are not logged in");
            }
            return theUpdatedUser;
        }

        public User addUserRegister(User newUser)
        {
            throw new NotImplementedException();
        }

        public User getUserByUserNameAndPasswordLogin(UserLogin userLogin)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(int id, User updatedUser)
        {
            throw new NotImplementedException();
        }

        public User addUserRegister(User newUser)
        {
            throw new NotImplementedException();
        }

        public User getUserByUserNameAndPasswordLogin(UserLogin userLogin)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(int id, User updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
