using End_Point_Parameters_Task.Models;

namespace End_Point_Parameters_Task.Sevices
{
    public interface IProductService
    {
        ProductOutputDTO AddProduct(ProductInputDTO inputDto);
        void DeleteProduct(int id);
        IEnumerable<ProductOutputDTO> GetAllProducts(int pageNumber, int pageSize);
        ProductOutputDTO GetProductById(int id);
        ProductOutputDTO UpdateProduct(int id, ProductInputDTO inputDto);
    }
}