namespace ECommerceApi.Domain.Entities;

public class BasketItem
{
    public int BasketItemId { get; set; }
    public int BasketId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }

    public Basket Basket { get; set; } = null!;
    public Product Product { get; set; } = null!;
}