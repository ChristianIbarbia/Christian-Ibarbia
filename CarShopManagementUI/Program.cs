using CarShopManagementData;
using CarShopManagementModels;

namespace Client
{
    internal class Program
    {

        static void Main(string[] args)
        {
            SqlDbData db = new SqlDbData();
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Delete User");
                Console.WriteLine("3. Update User");
                Console.WriteLine("4. Display Users");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your Action here");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter brand: ");
                        string brand = Console.ReadLine();
                        Console.Write("Enter model: ");
                        string model = Console.ReadLine();
                        int addSuccess = db.AddUser(brand, model);
                        Console.WriteLine(addSuccess > 0 ? "User added successfully." : "Error adding user.");
                        break;
                    case "2":
                        Console.Write("Enter brand to delete: ");
                        string deleteBrand = Console.ReadLine();
                        int deleteSuccess = db.DeleteUser(deleteBrand);
                        Console.WriteLine(deleteSuccess > 0 ? "User deleted successfully." : "Error deleting user.");
                        break;
                    case "3":
                        Console.Write("Enter brand to update: ");
                        string updateBrand = Console.ReadLine();
                        Console.Write("Enter new model: ");
                        string updateModel = Console.ReadLine();
                        Console.Write("Enter new status: ");
                        int updateStatus = Convert.ToInt32(Console.ReadLine());
                        int updateSuccess = db.UpdateUser(updateBrand, updateModel, updateStatus);
                        Console.WriteLine(updateSuccess > 0 ? "User updated successfully." : "Error updating user.");
                        break;
                    case "4":
                        List<User> users = db.GetUsers();
                        foreach (User user in users)
                        {
                            Console.WriteLine($"Brand: {user.brand}, Model: {user.model}, Status: {user.status}");
                        }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}