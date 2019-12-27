using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP_MVC_03.Models
{
    public class ASP_MVC_03Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ASP_MVC_03Context() : base("name=ASP_MVC_03Context")
        {
        }

        public DbSet<ASP_MVC_03.Models.Test> Tests { get; set; }

    }
}
