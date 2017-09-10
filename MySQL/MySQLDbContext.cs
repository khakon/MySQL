using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Common;
using MySql.Data.Entity;

namespace MySQL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(): base("Server=localhost;Database=Test;userId=root;CharSet=utf8;Persist Security Info=True")
        { }
        public DbSet<UserModel> UserModels { get; set; }
    }
}
