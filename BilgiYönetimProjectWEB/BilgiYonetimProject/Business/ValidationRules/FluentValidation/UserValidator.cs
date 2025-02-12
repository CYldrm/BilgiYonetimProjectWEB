using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            //RuleFor(p=>p.UnitPrice).GreaterThanOrEqualTo(10).when(p=>p.CategoryId==1);
            //Yukarıda örneğin e ticaret sisteminde eklenecek ürünün katagori idsi 1 se
            //en az 10 fiyatı olmalı
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.UserName).MinimumLength(2);
            RuleFor(u => u.UserName).Must(StartsWithUpperCase).WithMessage("İsim büyük harfle başlamalı.");
        }
        private bool StartsWithUpperCase(string userName)
        {
            char firstChar = userName[0];
            return char.IsUpper(firstChar);
        }
    }
}
