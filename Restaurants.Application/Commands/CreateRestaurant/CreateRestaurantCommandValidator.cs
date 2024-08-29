﻿using FluentValidation;

namespace Restaurants.Application.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name)
                .Length(3, 100);

            RuleFor(dto => dto.Category)
                 .Must(validCategories.Contains)
                 .WithMessage("Invalid category. please choose from the valid categories.");

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress()
                .WithMessage("Please provide  a valid email address");

            RuleFor(dto => dto.PostalCode)
                .Matches(@"\d{2}-\d{3}$")
                .WithMessage("please provide a valid postal code (XX-XXX).");
        }
    }
}
