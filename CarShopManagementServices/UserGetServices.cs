

using CarShopManagement;
using CarShopManagementData;
using CarShopManagementModels;

namespace CarshopManagementServices
{
    public class UserGetServices

    {
        List<User> GetAllUsers()
        {
            UserData userData = new UserData();

            return userData.GetUsers();

        }

        public List<User> GetUsersByStatus(int userStatus)
        {
            List<User> usersByStatus = new List<User>();

            foreach (var user in GetAllUsers())
            {
                if (user.status == userStatus)
                {
                    usersByStatus.Add(user);
                }
            }

            return usersByStatus;
        }

        public User GetUser(string brand, string model)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.brand == brand && user.model == model)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        public User GetUser(string brand)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.brand == brand)
                {
                    foundUser = user;
                }
            }

            return foundUser;

        }
 

    }
}
