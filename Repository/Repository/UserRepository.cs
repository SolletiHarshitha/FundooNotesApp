using Experimental.System.Messaging;
using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

        public bool ForgotPassword(string email)
        {
            try
            {
                var user = this.userContext.Users.Where(x => x.Email == email).FirstOrDefault();
                if(user != null)
                {
                    SendQueue();
                    var messageBody = ReceiveQueue();
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("soll17311.cs@rmkec.ac.in");
                    mailMessage.To.Add(new MailAddress(email));
                    mailMessage.Subject = "Link to reset password";
                    mailMessage.Body = messageBody;
                    mailMessage.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("soll17311.cs@rmkec.ac.in", "Password");

                    smtp.Send(mailMessage);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SendQueue()
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
            message.Body = "Click on the following  link to reset your password for FundooNotes App : https://localhost:44322/api/ResetPassword";
            sender.Label = "url link";
            sender.Send(message);
        }
        public static string ReceiveQueue()
        {
            MessageQueue receiver = new MessageQueue(@".\Private$\myqueue");
            var receive = receiver.Receive();
            receive.Formatter = new BinaryMessageFormatter();
            string linkToSend = receive.Body.ToString();
            return linkToSend;
        }

        public bool ResetPassword(ResetPasswordModel resetData)
        {
            try
            {
                string encodedPassword = EncryptPassword(resetData.NewPassword);
                var user = this.userContext.Users.Where(x => x.Email == resetData.Email).FirstOrDefault();
                if(user != null)
                {
                    user.Password = encodedPassword;
                    userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
