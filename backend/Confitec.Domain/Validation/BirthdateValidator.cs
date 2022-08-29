using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Validation
{
    public class BirthdateValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime birth = Convert.ToDateTime(value);
            return birth <= DateTime.Now;
        }
    }
}
