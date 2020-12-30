using System;
using System.Collections.Generic;
using System.Linq;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class BarmanRepository : IRepository<Barman>
    {
        private ApplicationContext db;

        public BarmanRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(Barman barman)
        {
            db.Barmen.Add(barman);
        }

        public void Delete(int id)
        {
            Barman barman = db.Barmen.Find(id);
            if (barman != null)
            {
                db.Barmen.Remove(barman);
            }
        }

        public IEnumerable<Barman> Find(Func<Barman, bool> predicate)
        {
            return db.Barmen.Include(b => b.Department).Where(predicate).ToList();
        }

        public Barman GetById(int id)
        {
            return db.Barmen.Find(id);
        }

        public IEnumerable<Barman> GetAll()
        {
            return db.Barmen.Include(b => b.Department);
        }

        public void Update(Barman barman)
        {
            db.Entry(barman).State = EntityState.Modified;
        }
    }
}
