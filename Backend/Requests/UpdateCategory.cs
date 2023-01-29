using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Requests
{
    public class UpdateCategory
    {
        public int id { set; get; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategory>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.NameAr).NotEmpty().NotNull().WithMessage("أملى الحقل");
            RuleFor(x => x.NameAr).NotEmpty().NotNull().WithMessage("Name Cannot be Empty");
        }
    }

}
