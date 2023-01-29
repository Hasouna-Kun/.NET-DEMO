using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Requests
{
    public class AddCustomer
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? Phone { get; set; }
        public string City { get; set; }
    }

    public class AddCustomerValidator : AbstractValidator<AddCustomer>
    {
        public AddCustomerValidator()
        {
            RuleFor(c => c.NameAr).NotEmpty().NotNull().WithMessage("أملى الحقل");
            RuleFor(c => c.NameEn).NotNull().NotEmpty().WithMessage("Name is Required");
            RuleFor(c => c.Phone).NotEmpty().NotNull().WithMessage("Enter Phone Number");
            RuleFor(c => c.City).NotNull().NotEmpty().WithMessage("Feild is Required");
        }
    }
}
