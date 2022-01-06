namespace EFSoft.Orders.Infrastructure.Entities;

public class Order
{
    [Key]
    public Guid OrderId { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public OrderStatus OrderStatus { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
