namespace ECommerceApi.Domain.Entities;

public class ProductPrice
{
    public int ProductPriceId { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddYears(1);
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }

    public Product Product { get; set; } = null!;
}