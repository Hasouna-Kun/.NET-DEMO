using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Requests
{
    public class UpdateCustomer
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? Phone { get; set; }
        public string City { get; set; }
    }

    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomer>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(c => c.NameAr).NotNull().NotEmpty().WithMessage("قم بتعبئة الحقل");
            RuleFor(c => c.NameEn).NotEmpty().NotNull().WithMessage("Name Feild is Required");
            RuleFor(c => c.Phone).NotNull().NotEmpty().WithMessage("Enter Phone Number");
            RuleFor(c => c.City).NotEmpty().NotNull().WithMessage("City Feild is Required");
        }
    }
}
