using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ShopManager.Presentation.API_v1.Validators;

namespace ShopManager.Presentation.API_v1.DataAnnotations;

public class AddProductRequest
{
    [MaxFileSize(5 * 1024 * 1024)] // 5MB
    [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" })]
    public List<IFormFile> Files { get; set; } = new List<IFormFile>();

    [Required]
    [StringLength(100)]
    public required string Name { get; set; }

    [Required]
    [StringLength(1000)]
    public required string Text { get; set; }

    [Required]
    public required List<string> Categories { get; set; }
    
    [Required]
    public required Decimal Price { get; set; }
    
    [Required]
    public required Guid StoreId { get; set; }
}
