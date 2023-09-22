using TableBallAPI.Models;

namespace TableBallAPI.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        IEnumerable<T> GetBySearchTerm(string term);
        List<T> GetMultipleById(List<T> ids);
        void Add(T entity);
        void Update(T entity);
        void UpdateMultiple (List<T> entities);
        void Delete(Guid id);
    }
}
