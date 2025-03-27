using Entity;
using System.Reflection.Metadata;
using System.Text.Json;

namespace IceCreamStoreRepostery
{
    public class IceCreamStoreReposteryUser
    {


        public User addUserRegister(User newUser)
        {
            string filePath = "User.txt";
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            newUser.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(newUser);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return newUser;
        }

        public User getUserByUserNameAndPasswordLogin(UserLogin userLogin)
            {
            string filePath = "./User.txt";
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User currentUser = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (userLogin.userName == currentUser.userName && currentUser.password == userLogin.password)
                    {

                        return currentUser;
                    }
                }
            }
            return null;

        }

    
     public User UpdateUser(User updatedUser)
        {
            string filePath = "./User.txt";
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == updatedUser.userId)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updatedUser));
                System.IO.File.WriteAllText(filePath, text);
                return updatedUser;
            }
            return null;
        }

            

        
    }
}
