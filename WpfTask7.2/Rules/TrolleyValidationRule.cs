using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfTask7._2.Models;

namespace WpfTask7._2.Rules
{
    public class TrolleyValidationRule : ValidationRule
    {
        public int Min { get; set; } = 2;
        public int Max { get; set; } = 60;


        public TrolleyValidationRule()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string str)
            {
                if (int.TryParse(str, out int count))
                {
                    if (count >= Min && count <= Max)
                    {
                        return new ValidationResult(true, null);
                    }
                    else
                    {
                        return new ValidationResult(false, $"Значение должно быть в диапазоне [{Min};{Max}]");
                    }
                }
                else
                {
                    return new ValidationResult(false, "Значение должно быть числом");
                }
            }
            else
            {
                return new ValidationResult(false, "Значение должно быть числом");
            }
        }
    }
}
