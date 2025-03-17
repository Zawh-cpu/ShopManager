using System.ComponentModel.DataAnnotations;

namespace ShopManager.Presentation.API_v1.Validators;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly HashSet<string> _extensions;

    public AllowedExtensionsAttribute(string[] extensions)
    {
        _extensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);
    }

    public override bool IsValid(object value)
    {
        if (value is not List<IFormFile> files) return false;
        return files.All(file => _extensions.Contains(Path.GetExtension(file.FileName)));
    }

    public override string FormatErrorMessage(string name)
    {
        return $"Разрешены только файлы: {string.Join(", ", _extensions)}";
    }
}