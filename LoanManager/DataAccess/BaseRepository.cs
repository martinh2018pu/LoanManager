using LoanManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoanManager.DataAccess
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected LoanManagerDbContext _loanManagerDbContext;
        protected DbSet<T> DbSet { get; set; }

        public BaseRepository()
        {
            _loanManagerDbContext = new LoanManagerDbContext();
            DbSet = _loanManagerDbContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Delete(int id)
        {
            var model = Get(id);
            DbSet.Remove(model);

            _loanManagerDbContext.SaveChanges();
        }

        public void Save(T model)
        {
            if (model.Id == 0)
            {
                Create(model);
            }
            else
            {
                Update(model);
            }

            _loanManagerDbContext.SaveChanges();
        }

        private void Create(T model)
        {
            DbSet.Add(model);
        }

        private void Update(T model)
        {
            _loanManagerDbContext.Entry(model).State = EntityState.Modified;
        }
}