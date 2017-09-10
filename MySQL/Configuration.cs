using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace MySQL
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MySQL.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {

        }
    }

    internal sealed class MySQLConfiguration : DbMigrationsConfiguration<MySQLDbContext>
    {
        public MySQLConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MySQL.MySQLDbContext";
        }

        protected override void Seed(MySQLDbContext context)
        {

        }
    }
}
