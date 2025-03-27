using Entity;
using IceCreamStoreRepostery;


namespace IceCreamStoreService
{
    public class IceCreamStoreServiceUser
    {
        public IceCreamStoreReposteryUser Repostery { get; set; }
        public List<User> getUsers()
        {
           return Repostery.getUsers();
        }
    }
}
