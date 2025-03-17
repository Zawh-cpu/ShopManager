using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ShopManager.Presentation.API_v1.Validators;

namespace ShopManager.Presentation.API_v1.DataAnnotations;

public class AddProductRequest
{
    [Required(ErrorMessage = "Файлы обязательны")]
    [MaxFileSize(5 * 1024 * 1024)] // 5MB
    [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" })]
    [FromForm(Name = "files")]
    public List<IFormFile> Files { get; set; }

    [Required]
    [FromForm(Name = "data")]
    public required AddProductDataRequest Data { get; set; }
}

public class AddProductDataRequest
{
    [Required(ErrorMessage = "Заголовок обязателен")]
    [StringLength(100, ErrorMessage = "Заголовок не должен превышать 100 символов")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Текст обязателен")]
    [StringLength(1000, ErrorMessage = "Текст не должен превышать 1000 символов")]
    public string Text { get; set; }

    [Required(ErrorMessage = "Категория обязательна")]
    [StringLength(50, ErrorMessage = "Категория не должна превышать 50 символов")]
    public string Category { get; set; }
}