// ----------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using Manager.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <summary>
    /// User Controller Class
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Object for IUserManager
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// Initializes a new instance of the UserController class
        /// </summary>
        /// <param name="manager"> IUserManager manager</param>
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Controller API for Registration
        /// </summary>
        /// <param name="userData">Details required for Registration</param>
        /// <returns>Result of the action</returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                bool result = this.manager.Register(userData);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "New User Added Successfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "User Added Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller API for /login
        /// </summary>
        /// <param name="loginData">Details required for Login</param>
        /// <returns>Result of the action</returns>
        [HttpGet]
        [Route("api/login")]
        public IActionResult Login([FromBody]LoginModel loginData)
        {
            try 
            {
                bool result = this.manager.Login(loginData);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Login Successfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller API for Forgot Password
        /// </summary>
        /// <param name="email">Required Email</param>
        /// <returns>Result of the action</returns>
        [HttpGet]
        [Route("api/ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                bool result = this.manager.ForgotPassword(email);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Request Sent Please Check The Mail!" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Email is Incorrect" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller API for Reset Password
        /// </summary>
        /// <param name="resetData">Details required for reset password</param>
        /// <returns>Result of the action</returns>
        [HttpPut]
        [Route("api/ResetPassword")]
        public IActionResult ResetPassword([FromBody]ResetPasswordModel resetData)
        {
            try 
            {
                bool result = this.manager.ResetPassword(resetData);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reset Password Successful!" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Reset Password is Unsuccessful.Email is Incorrect" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}