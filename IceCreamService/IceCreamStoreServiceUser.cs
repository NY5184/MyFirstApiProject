using Entity;
using IceCreamStoreRepostery;


namespace IceCreamStoreService
{
    public class IceCreamStoreServiceUser
    {
        public IceCreamStoreReposteryUser repostery;


        public User addUserRegister(User newUser)
        {
            return repostery.addUserRegister(newUser);
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
            User theUpdatedUser=repostery.UpdateUser(id,updatedUser);
            if(theUpdatedUser==null)
            {
                throw new KeyNotFoundException("you are not logged in");
            }
            return theUpdatedUser;
        }

    }
}
