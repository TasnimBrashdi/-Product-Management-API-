using End_Point_Parameters_Task.Models;

namespace End_Point_Parameters_Task.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();


        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
