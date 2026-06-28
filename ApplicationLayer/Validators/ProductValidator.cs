using ApplicationLayer.DTOS;
using DomanLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Validators
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {

            RuleFor(obj => obj.ProductName).NotEmpty().WithMessage("Product Name Cannot be empty");
            RuleFor(obj => obj.Category).NotEmpty().WithMessage("Category Cannot be empty");
            RuleFor(obj => obj.UnitPrice).GreaterThan(0).WithMessage("Price must be a positive value").NotEmpty().WithMessage("Price Cannot be empty");
            RuleFor(obj => obj.QuantityInStock).GreaterThanOrEqualTo(0).WithMessage("Quantity must be a non-negative value").NotEmpty().WithMessage("Quantity Cannot be empty")
                .NotNull().WithMessage("Quantity Cannot be null");

        }
    }
}
