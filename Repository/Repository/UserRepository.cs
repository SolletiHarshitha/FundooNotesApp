using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;

        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public bool Register(RegisterModel userData)
        {
            try
            {
                if (userData != null)
                {
                    userData.Password = EncryptPassword(userData.Password);
                    this.userContext.Users.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string EncryptPassword(string password)
        {
            try
            {
                byte[] passwordEncrypt = new byte[password.Length];
                passwordEncrypt = Encoding.UTF8.GetBytes(password);
                string encodedPassword = Convert.ToBase64String(passwordEncrypt);
                return encodedPassword;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Login(LoginModel loginData)
        {
            try
            {
                string encodedPassword = EncryptPassword(loginData.Password);
                var login = this.userContext.Users.Where(x => x.Email == loginData.Email && x.Password == encodedPassword).FirstOrDefault();
                if (login != null)
                    return true;
                else
                    return false;
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
