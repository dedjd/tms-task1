using TmsMvc.Models;

namespace TmsMvc.Services;

public interface IInventoryService
{
    ProductListModel GetProducts();

    CommandResultModel AddProduct(ProductModel product);

    CommandResultModel DeleteProduct(SelectProductModel product);

    CommandResultModel UpdateProduct(ProductModel product);

    ProductModel GetProductById(Guid id);
}
