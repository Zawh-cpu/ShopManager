using System.ComponentModel.DataAnnotations;

namespace ShopManager.Core.Entities;

public class Photo
{
    [Key] public required Guid Id { get; set; }
    
    [Required] public required Guid ParentId { get; set; }
    
    [Required] public required byte[] Data { get; set; }
}