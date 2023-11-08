namespace WebTmsTask11.Models;

public class ProductListModel
{
    public ProductModel[] Products { get; set; }

    public int Count { get; set; }

    public int TotalCount { get; set; }
}