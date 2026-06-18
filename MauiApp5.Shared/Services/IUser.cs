using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp5.Shared.Services
{
    public interface IUser
    {
        public int GetUserId(string userName);
        public User GetUser(int userId);
    }
}
