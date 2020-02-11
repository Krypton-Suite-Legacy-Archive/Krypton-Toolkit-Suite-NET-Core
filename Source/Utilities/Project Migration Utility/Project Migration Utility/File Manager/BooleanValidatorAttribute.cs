using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectMigrationUtility.FileManager
{
    internal class BooleanValidatorAttribute : ValidationAttribute
    {
        public BooleanValidatorAttribute() { }

        public override bool IsValid(object value)
        {
            bool boolValue;

            return bool.TryParse(Convert.ToString(value), out boolValue);
        }
    }
}