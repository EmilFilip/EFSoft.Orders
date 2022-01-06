namespace EFSoft.Orders.Infrastructure.Entities;

public class OrderProduct
{
    [Key]
    public Guid OrderProductId { get; set; }

    [Required]
    public Guid OrderId { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public int Quantity { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("OrderId")]
    public virtual Order Order { get; set; }
}

