// ----------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Manager
{
    using System;
    using global::Manager.Interface;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// User Manager Class
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// Object for IUserRepository
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the UserManager class
        /// </summary>
        /// <param name="repository">IUserRepository repository</param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Method for Register
        /// </summary>
        /// <param name="userData">Details required for Registration</param>
        /// <returns>Result of the action</returns>
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

        /// <summary>
        /// Method For Login
        /// </summary>
        /// <param name="loginData">Details required for Login</param>
        /// <returns>Result of the action</returns>
        public bool Login(LoginModel loginData) 
        {
            try
            {
                return this.repository.Login(loginData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method for Forgot Password
        /// </summary>
        /// <param name="email">Required Email</param>
        /// <returns>Result of the action</returns>
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

        /// <summary>
        /// Method for Reset Password
        /// </summary>
        /// <param name="resetData">Details required for Reset Password</param>
        /// <returns>Result of the action</returns>
        public bool ResetPassword(ResetPasswordModel resetData)
        {
            try
            {
                return this.repository.ResetPassword(resetData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
