using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp5.Shared.Services
{
    public class UserService : IUser
    {
        public AppDbContext Context { get; set; }
        public UserService()
        {
            Context = new AppDbContext();
        }
        public int GetUserId (string userName)
        {
            var T = Context.Users
                     .FirstOrDefault(x => x.name == userName).id;
            var T2 = Context.Users.ToArray();
            return T;
        }
        public User GetUser (int userId)
        {
            return Context.Users
                .FirstOrDefault(x => x.id == userId);
        }

    }
}
