// ----------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{
    using Models;

    /// <summary>
    /// IUserManager Interface
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Register Method
        /// </summary>
        /// <param name="userData">User Details for Registration</param>
        /// <returns>Returns the Result</returns>
        string Register(RegisterModel userData);

        /// <summary>
        /// Login Method
        /// </summary>
        /// <param name="loginData">User Details to Login</param>
        /// <returns>Returns the Result</returns>
        bool Login(LoginModel loginData);

        /// <summary>
        /// ForgotPassword Method
        /// </summary>
        /// <param name="email">Email to Reset Password</param>
        /// <returns>Returns the Result</returns>
        bool ForgotPassword(string email);

        /// <summary>
        /// ResetPassword Method
        /// </summary>
        /// <param name="resetData">UserDetails to Reset Password</param>
        /// <returns>Returns the Result</returns>
        bool ResetPassword(ResetPasswordModel resetData);

        /// <summary>
        /// Generates token
        /// </summary>
        /// <param name="email">Email Id</param>
        /// <returns>Token as  string</returns>
        string GenerateToken(string email);
    }
}
