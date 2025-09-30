namespace ECommerceApi.Domain.Entities;

public class ProductHiyerarchy
{
    public int ProductHiyerarchyId { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public int ParentCategoryId { get; set; }
    public int Level { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryPath { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }

    public Product Product { get; set; } = null!;
}