using Manager.Interface;
using Models;
using Repository.Interface;
using System;

namespace Manager.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public bool Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Login(LoginModel loginData) 
        {
            try
            {
                return this.repository.Login(loginData);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ForgotPassword(string email)
        {
            try
            {
                return this.repository.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
