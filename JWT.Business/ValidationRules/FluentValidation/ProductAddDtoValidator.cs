using FluentValidation;
using JWT.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Business.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("ad alanı boş geçilemez");
        }
    }
}
