using System.Threading.Tasks;
using TodayTest.Models.TokenAuth;
using TodayTest.Web.Controllers;
using Shouldly;
using Xunit;

namespace TodayTest.Web.Tests.Controllers
{
    public class HomeController_Tests: TodayTestWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}