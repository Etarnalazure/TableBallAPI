using Microsoft.EntityFrameworkCore;
using TableBallAPI.DatabaseContext;
using TableBallAPI.Interface;
using TableBallAPI.Models;

namespace TableBallAPI
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TableBallContext _dbContext;

        public Repository(TableBallContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }
 
        public List<T> GetMultipleById(List<T> entities)
        {
            return _dbContext.Set<T>().Where(entity => entities.Contains(entity)).ToList();
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void UpdateMultiple(List<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<T> GetBySearchTerm(string term)
        {
            string sqlWhere = "SELECT * FROM Player WHERE PlayerName LIKE '%" + term + "%' OR PlayerInitials LIKE '%" + term + "%'";
            return _dbContext.Set<T>().FromSqlRaw(sqlWhere);
        }

    }
}
