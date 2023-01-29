using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Requests
{
    public class AddCategory
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }

    public class AddCategoryValidator : AbstractValidator<AddCategory>
    {
        public AddCategoryValidator()
        {
            RuleFor(x => x.NameAr).NotEmpty().NotNull().WithMessage("name cannot be null");
            RuleFor(x => x.NameEn).NotEmpty().NotNull().WithMessage("name cannot be null");
        }
    }
}
