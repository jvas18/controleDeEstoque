using DTI.Domain.Product.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Domain.Product.Validators
{
    public class RemoveProductValidator : AbstractValidator<RemoveProduct>
    {
        public RemoveProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id é obrigatório");
        }
    }
}
