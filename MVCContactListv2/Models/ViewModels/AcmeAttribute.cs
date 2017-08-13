using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCContactListv2.Models.ViewModels
{
    public class AcmeAttribute : ValidationAttribute
    {
        string emailSuffix = "acme.com";

        public AcmeAttribute()
        {
        }

        public AcmeAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor)
        {
        }

        public AcmeAttribute(string errorMessage) : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                return (bool)value?.ToString().EndsWith(emailSuffix);

            }
            return false;
        }

    }
}
