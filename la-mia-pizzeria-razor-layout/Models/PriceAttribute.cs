using System.ComponentModel.DataAnnotations;

public class PriceAttribute : ValidationAttribute
{
    public decimal Price { get; set; }
    public PriceAttribute() { }
    public PriceAttribute(int price)
    {
        this.Price = price;
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        decimal fieldValue = (decimal)value;

        if (fieldValue == null || fieldValue < 0)
        {
            return new ValidationResult($"Insert a valid price");
        }

        return ValidationResult.Success;
    }
}


