using System.ComponentModel.DataAnnotations;

namespace WebShop.Data
{
    public class TwoDigitAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is short shortValue)
            {
                if (shortValue >= 10 && shortValue <= 99)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("The value must be a two-digit number.");
                }
            }

            return new ValidationResult("Invalid value.");
        }
    }

    public class Article
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Season { get; set; }

        [TwoDigit]
        public short CollectionType { get; set; }
        public string? CareInformation { get; set; }
        public string? FitInformation { get; set; }
        public string? MaterialInformation { get; set; }
        public virtual IList<ColorInfo> ColorInfos { get; set; }
    }
}
