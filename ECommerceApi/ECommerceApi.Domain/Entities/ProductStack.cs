namespace ECommerceApi.Domain.Entities;

public class ProductStack
{
    public int ProductStackId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int MinimumStack { get; set; } = 10;
    public int MaximumStack { get; set; } = 1000;
    public string Location { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }

    public Product Product { get; set; } = null!;
}