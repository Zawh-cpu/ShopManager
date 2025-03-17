using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManager.Core.Entities;

public class Product
{
    [Key]
    public uint Id { get; set; }
    
    public required string Name { get; set; }
    public required Decimal Price { get; set; }
    
    [Required]
    public required Guid StoreId { get; set; }
    
    public required Guid AddedByUserId { get; set; }
}