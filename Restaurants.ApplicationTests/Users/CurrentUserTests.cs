using FluentAssertions;
using Restaurants.Domain.Contants;
using Xunit;

namespace Restaurants.Application.Users.Tests
{
    public class CurrentUserTests
    {
        //TestMethod_Scenario_ExpectResult
        [Theory()]
        [InlineData(UserRoles.Admin)]
        [InlineData(UserRoles.User)]
        public void IsInRole_withMatchingRole_shouldReturnTrue(string roleName)
        {
            //arrage
            var currentUser = new CurrentUser("1","test@test.com", [UserRoles.Admin,UserRoles.User]);


            //act

           var isInRole =  currentUser.IsInRole(roleName);

            //assert/result

            isInRole.Should().BeTrue();
        }

        //TestMethod_Scenario_ExpectResult
        [Fact()]
        public void IsInRole_withNoMatchingRole_shouldReturnFalse()
        {
            //arrage
            var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User]);


            //act

            var isInRole = currentUser.IsInRole(UserRoles.Owner);

            //assert/result

            isInRole.Should().BeFalse();
        }

        //TestMethod_Scenario_ExpectResult
        [Fact()]
        public void IsInRole_withNoMatchingRoleCase_shouldReturnFalse()
        {
            //arrage
            var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User]);


            //act

            var isInRole = currentUser.IsInRole(UserRoles.Admin.ToLower());

            //assert/result

            isInRole.Should().BeFalse();
        }
    }
}