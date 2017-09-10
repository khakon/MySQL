using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL
{
    class Program
    {
        private static string connectionStr = "Server=localhost;Database=Test;user id=ma;MultipleActiveResultSets=true";
        private static string connectionMySQLStr = "Server=localhost;Database=Test;userId=root;CharSet=utf8;Persist Security Info=True";
        private static IRepository<UserModel> repo;
        private static bool useMySQl = true;
        static void Main(string[] args)
        {
            // create SQL database
            MigrateDb();
            // create MySQL database
            MigrateMySQLDb();
            // select repository
            if (useMySQl) repo = new MySQLRepository();
            else repo = new SQLRepository(connectionStr);
            // using repository
            using (repo)
            {
                repo.Create(new UserModel { UserName = "Test", Gender = "Test" });
                repo.Save();
                foreach (var u in repo.GetAll())
                {
                    Console.WriteLine($"{u.UserId}.{u.UserName} - {u.Gender}");
                }
            }
            Console.Read();
        }
        public static void MigrateDb()
        {
            var configuration = new Configuration();
            configuration.TargetDatabase = new DbConnectionInfo(connectionStr, "System.Data.SqlClient");
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }
        public static void MigrateMySQLDb()
        {
            var configuration = new MySQLConfiguration();
            configuration.TargetDatabase = new DbConnectionInfo(connectionMySQLStr, "MySql.Data.MySqlClient");
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }
    }
}
