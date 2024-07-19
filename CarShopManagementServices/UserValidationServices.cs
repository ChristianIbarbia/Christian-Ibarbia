using CarshopManagementServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopManagementServices
{
    public class UserValidationServices
    {
        internal bool CheckIfUserNameExists(string brand)
        {
            throw new NotImplementedException();

            UserGetServices getservices = new UserGetServices();

            bool CheckIfUserNameExists(string brand)
            {
                bool result = getservices.GetUser(brand) != null;
                return result;
            }

            bool CheckIfUserExists(string brand, string model)
            {
                bool result = getservices.GetUser(brand, model) != null;
                return result;

            }
        }
    }
}
