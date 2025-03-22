using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManager.Core.Entities;

public class Product
{
    [Key]
    public uint Id { get; set; }
    
    [StringLength(100)]
    public required string Name { get; set; }
    
    [StringLength(1000)]
    public required string Text { get; set; }
    
    public required List<string> Categories { get; set; }
    
    public required Decimal Price { get; set; }
    
    [Required]
    public required Guid StoreId { get; set; }
    
    public required Guid AddedByUserId { get; set; }
    
    public required DateTime AddedOn { get; set; }
    
}