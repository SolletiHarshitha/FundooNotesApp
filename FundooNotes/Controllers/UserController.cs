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
    using Microsoft.Extensions.Logging;
    using Models;
    using StackExchange.Redis;

    /// <summary>
    /// User Controller Class
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Object for IUserManager
        /// </summary>
        private readonly IUserManager manager;

        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Initializes a new instance of the UserController class
        /// </summary>
        /// <param name="manager"> IUserManager manager</param>
        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this._logger = logger;
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
                _logger.LogInformation(userData.FirstName + " is trying to register");
                string expectedResult = "Registration Successful";
                string actualResult = this.manager.Register(userData);
                if (expectedResult.Equals(actualResult))
                {
                    _logger.LogInformation(userData.FirstName + " has successfully registered");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "New User Added Successful", Data = actualResult });
                }
                else
                {
                    _logger.LogInformation("Registration Unsuccessful");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Registration Unsuccessful", Data = actualResult });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(userData.FirstName + " got an exception");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller API for /login
        /// </summary>
        /// <param name="loginData">Details required for Login</param>
        /// <returns>Result of the action</returns>
        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody]LoginModel loginData)
        {
            try 
            {
                bool result = this.manager.Login(loginData);
                string resultMessage = this.manager.GenerateToken(loginData.Email);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Login Successfull", Data = resultMessage });
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