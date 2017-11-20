using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess;
namespace BusinessLogic
{
    public class UserLogic
    {
        public bool AddUsers(Users user)
        {
            HandleUserData handleUserData = new HandleUserData();
            handleUserData.AddUserData(user);
            return true;
        }

        public string[] GetLoginDetails(string name, string password)
        {
            Users UserDatatoReturn = new Users();
            string[] name2 = new string[2];
            HandleUserData handleUserData = new HandleUserData();
            name2=handleUserData.GetUserWithId(name,password);
            return name2;
        }


    }
}
