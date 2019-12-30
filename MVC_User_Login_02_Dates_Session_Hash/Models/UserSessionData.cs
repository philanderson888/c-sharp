using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_User_Login.Models
{
    [Serializable]
    public class UserSession
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime LastActiveClick { get; set; }
    }
}