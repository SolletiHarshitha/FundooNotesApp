// ----------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Interface
{
    using Models;

    /// <summary>
    /// IUserRepository repository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Register Method
        /// </summary>
        /// <param name="userData">User Details for Registration</param>
        /// <returns>Returns the Result</returns>
        bool Register(RegisterModel userData);

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
    }
}
