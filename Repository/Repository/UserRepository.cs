// ----------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using Experimental.System.Messaging;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    /// User Repository Class
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// IConfiguration configuration
        /// </summary>
        private readonly IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the UserRepository class
        /// </summary>
        /// <param name="userContext">UserContext userContext</param>
        /// <param name="configuration">IConfiguration configuration</param>
        public UserRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.config = configuration;
        }

        /// <summary>
        /// Method for Register
        /// </summary>
        /// <param name="userData">Details required for Registration</param>
        /// <returns>Result of the action</returns>
        public string Register(RegisterModel userData)
        {
            try
            {
                var newUser = this.userContext.Users.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (newUser == null)
                {
                    if (userData != null)
                    {
                        userData.Password = this.EncryptPassword(userData.Password);
                        this.userContext.Users.Add(userData);
                        this.userContext.SaveChanges();
                        return "Registration Successful";
                    }

                    return "Registration Unsuccessful";
                }

                return "The given Email already exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to encrypt the password
        /// </summary>
        /// <param name="password">Password to encrypt</param>
        /// <returns>Resultant string</returns>
        public string EncryptPassword(string password)
        {
            try
            {
                byte[] passwordEncrypt = new byte[password.Length];
                passwordEncrypt = Encoding.UTF8.GetBytes(password);
                string encodedPassword = Convert.ToBase64String(passwordEncrypt);
                return encodedPassword;
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
                string encodedPassword = this.EncryptPassword(loginData.Password);
                var login = this.userContext.Users.Where(x => x.Email == loginData.Email && x.Password == encodedPassword).FirstOrDefault();
                if (login != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentNullException ex)
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
                var user = this.userContext.Users.Where(x => x.Email == email).FirstOrDefault();
                if (user != null)
                {
                    this.SendQueue();
                    var message = this.ReceiveQueue();
                    if (this.Mail(email, message))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Method to Send Message into Queue
        /// </summary>
        public void SendQueue()
        {
            MessageQueue sender = new MessageQueue();
            if (MessageQueue.Exists(@".\Private$\myqueue"))
            {
                sender = new MessageQueue(@".\Private$\myqueue");
            }
            else
            {
                sender = MessageQueue.Create(@".\Private$\myqueue");
            }

            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Body = "Click on the following  link to reset your password for FundooNotes App ";
            sender.Label = "url link";
            sender.Send(message);
        }

        /// <summary>
        /// Method for Receiving message
        /// </summary>
        /// <returns>Resultant string</returns>
        public string ReceiveQueue()
        {
            MessageQueue receiver = new MessageQueue(@".\Private$\myqueue");
            var receive = receiver.Receive();
            receive.Formatter = new BinaryMessageFormatter();
            string link = receive.Body.ToString();
            return link;
        }
        
        /// <summary>
        /// Mail Method to send email
        /// </summary>
        /// <param name="email">Email to send</param>
        /// <param name="message">Message from the receive queue</param>
        /// <returns>Resultant value</returns>
        public bool Mail(string email, string message)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("soll17311.cs@rmkec.ac.in");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Link to reset password";
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("soll17311.cs@rmkec.ac.in", "password");

            smtp.Send(mailMessage);
            return true;
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
                string encodedPassword = this.EncryptPassword(resetData.NewPassword);
                var user = this.userContext.Users.Where(x => x.Email == resetData.Email).FirstOrDefault();
                if (user != null)
                {
                    user.Password = encodedPassword;
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Token Generation
        /// </summary>
        /// <param name="email">Required Email</param>
        /// <returns>Generates token</returns>
        public string GenerateToken(string email)
        {
            var key = Encoding.UTF8.GetBytes(this.config["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}