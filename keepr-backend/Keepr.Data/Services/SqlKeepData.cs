using Keepr.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keepr.Data.Services
{
    public class SqlKeepData : IKeepData
    {
        private readonly KeeprDbContext db;

        public SqlKeepData(KeeprDbContext db)
        {
            this.db = db;
        }

        public void Add(Keep keep)
        {
            db.Keeps.Add(keep);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var keep = db.Keeps.Find(id);
            db.Keeps.Remove(keep);
            db.SaveChanges();
        }

        public Keep Get(int id)
        {
            return db.Keeps.FirstOrDefault(k => k.Id == id);
        }

        public IEnumerable<Keep> GetAll()
        {
            return db.Keeps.OrderBy(k => k.Name);
        }

        public void Update(Keep keep)
        {
            var entry = db.Entry(keep);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

    }
}
