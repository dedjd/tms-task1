using WebTmsTask11.Models;

namespace WebTmsTask11.Services;

public class InventoryService : IInventoryService
{
    public List<ProductModel> Products { get; } = new List<ProductModel>();

    public CommandResultModel AddProduct(AddProductModel product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            return new CommandResultModel
            {
                Success = false,
                Message = "Name is empty",
            };
        }

        Products.Add(new ProductModel
        {
            Id = Guid.NewGuid(),
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
        });

        return new CommandResultModel
        {
            Success = true,
            Message = "Ok",
        };
    }

    public ProductListModel GetProducts()
    {
        return new ProductListModel
        {
            Products = Products.ToArray(),
            Count = Products.Count(),
            TotalCount = TotalCount()
        };
    }

    public int TotalCount()
    {
        var totalQuantity = 0;

        foreach (var product in Products)
        {
            totalQuantity += product.Quantity;
        }

        return totalQuantity;
    }

    public CommandResultModel GetTotalCost()
    {
        decimal totalSum = 0;

        foreach (var product in Products)
        {
            totalSum += product.Price * product.Quantity;
        }

        if (totalSum < 0)
        {
            return new CommandResultModel
            {
                Success = false,
                Message = $"Total cost of products is less than zero",
            };
        }

        return new CommandResultModel
        {
            Success = true,
            Message = $"The total cost of all products is {totalSum}",
        };
    }

    public CommandResultModel GetProductCost(SelectProductModel selectedProduct)
    {
        var product = Products.FirstOrDefault(p => p.Id == selectedProduct.Id);

        if (product == null)
        {
            return new CommandResultModel
            {
                Success = false,
                Message = $"There is no such product",
            };
        }

        var totalPrice = product.Price * product.Quantity;

        return new CommandResultModel
        {
            Success = true,
            Message = $"The total cost of the selected product is {totalPrice}",
        };
    }

    public CommandResultModel DeleteProduct(SelectProductModel selectedProduct)
    {
        var product = Products.FirstOrDefault(p => p.Id == selectedProduct.Id);

        if (product == null)
        {
            return new CommandResultModel
            {
                Success = false,
                Message = "Product not found",
            };
        }

        Products.Remove(product);

        return new CommandResultModel
        {
            Success = true,
            Message = "Product deleted",
        };
    }

    public CommandResultModel UpdateProduct(UpdateProductModel updatedProduct)
    {
        var product = Products.FirstOrDefault(p => p.Id == updatedProduct.Id);

        if (product == null)
        {
            return new CommandResultModel
            {
                Success = false,
                Message = "Product not found",
            };
        }

        if (updatedProduct.NewName != null)
        {
            product.Name = updatedProduct.NewName;
        }

        if (updatedProduct.NewPrice.HasValue)
        {
            product.Price = updatedProduct.NewPrice.Value;
        }

        if (updatedProduct.NewQuantity.HasValue)
        {
            product.Quantity = updatedProduct.NewQuantity.Value;
        }

        return new CommandResultModel
        {
            Success = true,
            Message = "Product updated",
        };
    }
}
