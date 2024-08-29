using FluentValidation.TestHelper;
using Xunit;

namespace Restaurants.Application.Commands.CreateRestaurant.Tests
{
    public class CreateRestaurantCommandValidatorTests
    {
        [Fact()]
        public void Validator_forValidCommand_shouldNotHaveValidationErrors()
        {
            //arrange

            var command = new CreateRestaurantCommand()
            {
               Name ="Test",
               Category ="Italian",
               ContactEmail ="test@test.com",
               PostalCode="12-345",

            };

            var validator = new CreateRestaurantCommandValidator();

            //act

            var reslut = validator.TestValidate(command);

            //assert

            reslut.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void Validator_forInvalidCommand_shouldHaveValidationErrors()
        {
            //arrange

            var command = new CreateRestaurantCommand()
            {
                Name = "Te",
                Category = "Ita",
                ContactEmail = "@test.com",
                PostalCode = "1345",

            };

            var validator = new CreateRestaurantCommandValidator();

            //act

            var reslut = validator.TestValidate(command);

            //assert

            reslut.ShouldHaveValidationErrorFor(c => c.Name);
            reslut.ShouldHaveValidationErrorFor(c => c.Category);
            reslut.ShouldHaveValidationErrorFor(c => c.ContactEmail);
            reslut.ShouldHaveValidationErrorFor(c => c.PostalCode);
        }

        [Theory()]
        [InlineData("Italian")]
        [InlineData("Mexican")]
        [InlineData("Japanese")]
        [InlineData("American")]
        [InlineData("Indian")]

        public void Validator_ForValidCategory_shouldNotHaveValidationErrorsForCategoryProperty(string category)
        {
            //arrange

            var validator = new CreateRestaurantCommandValidator();
            var command = new CreateRestaurantCommand() 
            {
                Category = category 
            };

            //act

            var result = validator.TestValidate(command);
            
            //assert

            result.ShouldNotHaveValidationErrorFor(c=> c.Category);
        }
    }
}