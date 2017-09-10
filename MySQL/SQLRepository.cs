using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL
{
    public class SQLRepository : IRepository<UserModel>
    {
        private ApplicationDbContext db;

        public SQLRepository(string connString)
        {
            this.db = new ApplicationDbContext(connString);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return db.UserModels;
        }

        public UserModel Get(int id)
        {
            return db.UserModels.Find(id);
        }

        public void Create(UserModel item)
        {
            db.UserModels.Add(item);
        }

        public void Update(UserModel item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            UserModel item = db.UserModels.Find(id);
            if (item != null)
                db.UserModels.Remove(item);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
