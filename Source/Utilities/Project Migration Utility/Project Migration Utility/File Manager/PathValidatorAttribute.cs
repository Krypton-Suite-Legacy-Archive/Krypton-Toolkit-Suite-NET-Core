using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectMigrationUtility.FileManager
{
    internal class PathValidatorAttribute : ValidationAttribute
    {
        public PathValidatorAttribute() { }

        public override bool IsValid(object value)
        {
            bool flag;

            try
            {
                Directory.Exists(Convert.ToString(value));

                return true;
            }
            catch (Exception e)
            {
                flag = false;
            }

            return flag;
        }
    }
}