namespace WebTmsTask11.Models;

public class UpdateProductModel
{
    public Guid Id { get; set; }

    public string NewName { get; set; }

    public decimal? NewPrice { get; set; }

    public int? NewQuantity { get; set; }
}