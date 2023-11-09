namespace TmsMvc.Models;

public class ProductListModel
{
    public ProductModel[] Products { get; set; }

    public int Count { get; set; }

    public int TotalCount { get; set; }

    public decimal TotalCost { get; set; }
}