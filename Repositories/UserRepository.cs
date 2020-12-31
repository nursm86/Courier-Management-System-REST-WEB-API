using Courier_Management_REST_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace Courier_Management_REST_WEB_API.Repositories
{
    public class UserRepository : Repository<User>
    {
        public string Validate(string encodedString)
        {
            string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
            string[] splittedText = decodedString.Split(new char[] { ':' });
            string userName = splittedText[0];
            string password = splittedText[1];

            User user = this.GetAll().Where<User>(x => x.UserName == userName && x.Password== password).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
                return user.UserName;
            }
        }
        public bool Validate(User u)
        {
            User user = this.GetAll().Where<User>(x => x.UserName == u.UserName && x.Password == u.Password).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UpdateUser(User user)
        {
            User oldUser = Get(user.Id);
            if (oldUser != null)
            {
                oldUser.Password = user.Password;
                oldUser.image = user.image;
                this.context.SaveChanges();
                return true;
            }
            return false;
        }

        public int getIdbyUserName(User u)
        {
            User user = this.GetAll().Where<User>(x => x.UserName == u.UserName).FirstOrDefault();
            return user.Id;
        }
        public void UpdatePassword(int id,string password)
        {
            User usertoChange = Get(id);
            usertoChange.Password = password;
            Update(usertoChange);
        }

        public void verifyUser(int id)
        {
            User user =  Get(id);
            user.Status = 1;
            Update(user);
        }

        public void blockUser(int id)
        {
            User user = Get(id);
            user.Status = 2;
            Update(user);
        }
        public void UnblockUser(int id)
        {
            User user = Get(id);
            user.Status = 1;
            Update(user);
        }

        public int getByUserName(string u)
        {
            User user =  GetAll().Where<User>(x => x.UserName == u).FirstOrDefault();
            return user.Id;
        }

        public void insertUser(User u,Customer c)
        {
            u.UserType = 2;
            u.UpdatedDate = DateTime.Now;
            u.image = null;
            this.context.Users.Add(u);
            this.context.SaveChanges();
            c.userId = getByUserName(u.UserName);
            c.UpdatedDate = DateTime.Now;
            this.context.Customers.Add(c);
            this.context.SaveChanges();
        }

        public bool ValidatePassword(int id,string pass)
        {
            User user = GetAll().Where<User>(x => x.Id == id && x.Password == pass).FirstOrDefault();

            if(user == null)
            {
                return true;
            }
            return false;
        }
    } 
}