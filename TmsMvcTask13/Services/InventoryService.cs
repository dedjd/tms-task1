using TmsMvc.Models;

namespace TmsMvc.Services;

public class InventoryService : IInventoryService
{
    public List<ProductModel> Products { get; } = new List<ProductModel>();

    public CommandResultModel AddProduct(ProductModel product)
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
            TotalCount = TotalCount(),
            TotalCost = GetTotalCost()
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

    public CommandResultModel UpdateProduct(ProductModel updatedProduct)
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

        product.Name = updatedProduct.Name;

        product.Price = updatedProduct.Price;

        product.Quantity = updatedProduct.Quantity;


        return new CommandResultModel
        {
            Success = true,
            Message = "Product updated",
        };
    }

    public decimal GetTotalCost()
    {
        decimal totalSum = 0;

        foreach (var product in Products)
        {
            totalSum += product.Price * product.Quantity;
        }

        return totalSum;
    }

    public ProductModel GetProductById(Guid id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return null;
        }

        return product;
    }

}
