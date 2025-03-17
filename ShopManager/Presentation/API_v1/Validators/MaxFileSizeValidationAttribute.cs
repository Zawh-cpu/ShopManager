using System.ComponentModel.DataAnnotations;

namespace ShopManager.Presentation.API_v1.Validators;

public class MaxFileSizeAttribute : ValidationAttribute
{
    private readonly long _maxSize;
    public MaxFileSizeAttribute(long maxSize)
    {
        _maxSize = maxSize;
    }

    public override bool IsValid(object value)
    {
        if (value is not List<IFormFile> files) return false;
        return files.All(file => file.Length <= _maxSize);
    }

    public override string FormatErrorMessage(string name)
    {
        return $"Максимальный размер файла: {_maxSize / (1024 * 1024)}MB";
    }
}