namespace ECommerceApi.Domain.Entities;

public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();

}