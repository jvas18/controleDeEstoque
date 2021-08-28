using DTI.Domain.Product.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Domain.Product.Validators
{
    public static class RegisterProductValidator 
    {
        public static void RegisterRules<T>(this AbstractValidator<T> validator)
           where T : CreateProduct
        {
            validator.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            validator.RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Preço é obrigatório");
            validator.RuleFor(x => x.Qtd)
                .NotEmpty()
                .WithMessage("Quantidade é obrigatória");
        }

        public class  CreateProductValidator : AbstractValidator<CreateProduct>
        {
            public CreateProductValidator()
            {
                this.RegisterRules();
            }
        }
        public class UpdateProductValidator : AbstractValidator<UpdateProduct>
        {
            public UpdateProductValidator()
            {
                this.RegisterRules();
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .WithMessage("Id é obrigatório");
            }
        }
    }
}
