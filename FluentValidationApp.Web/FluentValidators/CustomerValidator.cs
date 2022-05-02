using FluentValidation;
using FluentValidationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanı boş bırakılamaz")
                .EmailAddress().WithMessage("Mail formatına uygun bir e-posta adresi girilmelidir");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Yaş alanı boş bırakılamaz")
                .InclusiveBetween(18, 60).WithMessage("Yaş aralığı 18-60 olmalıdır");
        }
    }
}
