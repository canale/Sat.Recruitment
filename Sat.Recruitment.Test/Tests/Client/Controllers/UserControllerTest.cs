using Sat.Recruitment.Api.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test.Tests.Client.Controllers
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTest : BaseTest<UsersController>
    {


     /*   [Fact]
        public async Task CreateUser_WithExistentRecord_ShouldGetDuplicateError()
        {
            // Arrange
            string name = "Mike";
            string email = "mike@gmail.com";
            string address = "Av. Juan G";
            string phoneNumber = "+349 1122354215";
            string userType = "Normal";
            string money = "124";


            var SUT = CreateSUT();

            // Action

            var act = await SUT.CreateUser(name, email, address, phoneNumber, userType, money);

            // Assertion
            Assert.Equal(true, act.IsSuccess);
            Assert.Equal("User Created", act.Errors);

        }*/
/*
        [Fact]
        public void Test2()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.Equal(false, result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }*/
    }
}
