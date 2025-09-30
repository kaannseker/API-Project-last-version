namespace ECommerceApi.Domain.Entities;

public class Basket
{
    public int BasketId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public User User { get; set; } = null!;
    public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
}