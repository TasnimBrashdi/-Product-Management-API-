using End_Point_Parameters_Task.Models;

namespace End_Point_Parameters_Task.Repositories
{
    public interface IProductRepo
    {
        void Add(Product product);
        void Delete(int id);
        IQueryable<Product> GetAll();
        Product GetById(int id);
        void Update(Product product);
    }
}