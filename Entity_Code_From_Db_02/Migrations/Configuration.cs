namespace Entity_Code_From_Db_02.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Entity_Code_From_Db_02.SchoolModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        //    AutomaticMigrationDataLossAllowed = true;   
        }

        protected override void Seed(Entity_Code_From_Db_02.SchoolModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
