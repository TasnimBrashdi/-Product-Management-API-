using End_Point_Parameters_Task.Models;
using End_Point_Parameters_Task.Repositories;

namespace End_Point_Parameters_Task.Sevices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepository;

        public ProductService(IProductRepo productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductOutputDTO AddProduct(ProductInputDTO inputDto)
        {
            var product = new Product
            {
                Name = inputDto.Name,
                Price = inputDto.Price,
                Category = inputDto.Category,
                DateAdded = DateTime.UtcNow
            };

            _productRepository.Add(product);


            return new ProductOutputDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = product.DateAdded
            };
        }
        public IEnumerable<ProductOutputDTO> GetAllProducts(int pageNumber, int pageSize)
        {
            var products = _productRepository.GetAll().OrderByDescending(p => p.DateAdded)
                .Skip((pageNumber - 1) * pageSize)// skips a specified number of elements in the query's result set.((pageNumber - 1) * pageSize)
                .Take(pageSize)//retrieves the next specified number of elements after skipping.
                .Select(p => new ProductOutputDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.Category,
                    DateAdded = p.DateAdded
                });

            return products;
        }
        public ProductOutputDTO GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product not found.");
            }

            return new ProductOutputDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = product.DateAdded
            };
        }
        public ProductOutputDTO UpdateProduct(int id, ProductInputDTO inputDto)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {id} not found.");
            }

            product.Name = inputDto.Name;
            product.Price = inputDto.Price;
            product.Category = inputDto.Category;

            _productRepository.Update(product);


            return new ProductOutputDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = product.DateAdded
            };
        }
        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {id} not found.");
            }

            _productRepository.Delete(product.PID);

        }


    }
}
