using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToteBiz.Business
{
   public class UserRegister
    {
        private List<User> user = new List<User>();
        public UserRegister()
        {
            this.user.Add(new User { Id = 1, Login = "admin", Email = "admin@mail.com", Password = "admin", RePassword = "admin" });
            this.user.Add(new User { Id = 2, Login = "user", Email = "user@mail.com", Password = "user", RePassword = "user" });

        }
        public void Registration(User userReg)
        {
            int id = 0;
            if (userReg.Password != userReg.RePassword)
            {
                throw new UserException("Passwords do not match");

            }
            foreach (User listUser in this.user)
            {
                if (listUser.Login == userReg.Login)
                {
                    throw new UserException("User already exists");
                }
                if (listUser.Id > id)
                {
                    id = listUser.Id;
                }
            }

            userReg.Id = id + 1;
            this.user.Add(userReg);
        }
    }
}
