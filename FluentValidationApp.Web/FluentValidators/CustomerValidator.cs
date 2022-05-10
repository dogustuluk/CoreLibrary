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
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage)
                .EmailAddress().WithMessage("Mail formatına uygun bir e-posta adresi girilmelidir");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage)
                .InclusiveBetween(18, 60).WithMessage(NotEmptyMessage);

            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {//custom validate için must kullanılır.
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18'den büyük olmalıdır");
        }
    }
}
