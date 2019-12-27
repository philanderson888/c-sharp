using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_User_Login.Models
{
    public class UserLoginModel : DbContext
    {
        public UserLoginModel() : base("name=UserLoginDatabase") { }
        public DbSet<User> Users { get; set; }
    }
}