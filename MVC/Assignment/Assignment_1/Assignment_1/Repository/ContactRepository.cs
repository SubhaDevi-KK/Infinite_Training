using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Assignment_1.Models;


namespace Assignment_1.Repository
{
    public class ContactRepository<T> : IContactRepository<T> where T : class
    {
        ContactContext db;
        DbSet<T> dbset;

        public ContactRepository()
        {
            db = new ContactContext();
            dbset = db.Set<T>();
        }
        public void Delete(object Id)
        {
            T getModel = dbset.Find(Id);
            dbset.Remove(getModel);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetByID(object Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T obj)
        {
            dbset.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}