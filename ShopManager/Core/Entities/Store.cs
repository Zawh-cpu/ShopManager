using System.ComponentModel.DataAnnotations;

namespace ShopManager.Core.Entities;

public class Store
{
    [Key] public required Guid Id { get; set; }
    
    [Required] public required string Name { get; set; }
    
    [Required] public required string Location { get; set; }
    
    [Required] public required JsonContent Schedule { get; set; }
    
    [Required] public required byte[] Data { get; set; }
}