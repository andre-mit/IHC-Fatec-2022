using System.ComponentModel.DataAnnotations;

namespace VendaCarros.Utils.Attributes;

public class ConditionalRequired : ValidationAttribute
{
    private readonly string _propertyName;
    private readonly object _expectedValue;

    public ConditionalRequired(string propertyName, object expectedValue)
    {
        _propertyName = propertyName;
        _expectedValue = expectedValue;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var property = validationContext.ObjectType.GetProperty(_propertyName);
        if (property == null)
        {
            return new ValidationResult($"Property {_propertyName} not found");
        }
        var propertyValue = property.GetValue(validationContext.ObjectInstance, null);
        if (propertyValue == null)
        {
            return new ValidationResult($"Property {_propertyName} is null");
        }

        if (propertyValue.Equals(_expectedValue))
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        return ValidationResult.Success;
    }
}