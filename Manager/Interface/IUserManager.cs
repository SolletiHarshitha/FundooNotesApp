using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IUserManager
    {
        bool Register(RegisterModel userData);
        bool Login(LoginModel loginData);
        bool ForgotPassword(string email);
    }
}
