using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;
using Google.Protobuf.WellKnownTypes;

namespace Casablanca.Utils
{
    public class JMBValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string jmb = value as string;

            if (string.IsNullOrWhiteSpace(jmb))
            {
                return new ValidationResult(false, "JMB is required.");
            }

            if (jmb.Length != 13)
            {
                return new ValidationResult(false, "JMB must be exactly 13 characters.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
