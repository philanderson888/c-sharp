namespace ASP_MVC_04
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ASP_MVC_04_Model : DbContext
    {
        public ASP_MVC_04_Model()
            : base("name=ASP_MVC_04_Model")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<ASP_MVC_04.Models.Person> People { get; set; }
    }
}
