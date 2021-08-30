using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        public bool Register(RegisterModel userData);
        public bool Login(LoginModel loginData);
    }
}
