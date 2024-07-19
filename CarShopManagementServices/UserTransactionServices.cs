using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShopManagement;
using CarShopManagementData;
using CarShopManagementModels;



namespace CarShopManagementServices
{
    public class UserTransactionServices
    {

        UserValidationServices validationServices = new UserValidationServices();
        UserData userData = new UserData();

        public bool CreateUser(string brand, User user)
        {
            bool result = validationServices.CheckIfUserNameExists(user.brand);

            if (result)
            {
                userData.AddUser(user);
            }

            return result;
        }

        public string CreateUser(string brand, string model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string brand, string model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(string brand, User user)
        {
            bool result = validationServices.CheckIfUserNameExists(user.brand);

            if (result)
            {
                userData.UpdateUser(user);
            }

            return result;

        }

        public object UpdateUser(string brand, string model)
        {
            throw new NotImplementedException();
        }
    }
}