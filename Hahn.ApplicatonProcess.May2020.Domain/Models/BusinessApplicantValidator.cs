using FluentValidation;
using Hahn.ApplicatonProcess.May2020.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public class BusinessApplicantValidator : AbstractValidator<BusinessApplicant>
    {
        public BusinessApplicantValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Name can't be null")
                .MinimumLength(5)
                .WithMessage("Name should be at least 5 characters");

            RuleFor(x => x.FamilyName)
                .MinimumLength(5)
                .WithMessage("Name should be at least 5 characters");

            RuleFor(x => x.Address)
                .MinimumLength(5)
                .WithMessage("Name should be at least 10 characters");

            RuleFor(x => x.CountryOfOrigin)
                .Must(args => CheckCountry.isCountryValid(args))
                .WithMessage("Please provide a valid country.");

            RuleFor(x => x.EmailAddress)
                .EmailAddress()
                .WithMessage("Please provide a valid email address.");

            RuleFor(x => x.Age)
                .InclusiveBetween(20, 60)
                .WithMessage("Age should be between 20 and 60 inclusive.");

            RuleFor(x => x.Hired)
                .NotNull();
        }
    }
}
