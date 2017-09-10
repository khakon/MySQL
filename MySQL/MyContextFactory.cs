using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL
{
    public class MyContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext("Server=localhost;Database=Test;user id=ma;MultipleActiveResultSets=true");
        }
    }
    public class MySQLContextFactory : IDbContextFactory<MySQLDbContext>
    {
        public MySQLDbContext Create()
        {
            return new MySQLDbContext();
        }
    }
}
