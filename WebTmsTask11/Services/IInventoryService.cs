using WebTmsTask11.Models;

namespace WebTmsTask11.Services;

public interface IInventoryService
{
    ProductListModel GetProducts();

    CommandResultModel AddProduct(AddProductModel product);

    CommandResultModel GetTotalCost();

    CommandResultModel GetProductCost(SelectProductModel product);

    CommandResultModel DeleteProduct(SelectProductModel product);

    CommandResultModel UpdateProduct(UpdateProductModel product);
}
