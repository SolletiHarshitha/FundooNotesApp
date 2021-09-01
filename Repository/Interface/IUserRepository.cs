using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        bool Register(RegisterModel userData);
        bool Login(LoginModel loginData);
        bool ForgotPassword(string email);
        bool ResetPassword(ResetPasswordModel resetData);
    }
}
