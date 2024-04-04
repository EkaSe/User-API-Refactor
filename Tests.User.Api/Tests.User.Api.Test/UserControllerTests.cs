using Microsoft.AspNetCore.Mvc;
using Tests.User.Api.Controllers;
using Tests.User.Api.Services;

namespace Tests.User.Api.Test
{
    public class UserControllerTests
    {
        [Fact]
        public async Task Should_Return_User_When_Valid_Id_Passed()
        {
            DatabaseContext database = new();
            Models.User user = new()
            {
                FirstName = "Test",
                LastName = "User",
                Age = 20
            };
            database.Users.Add(user);
            database.SaveChanges();

            UserService userService = new();

            UserController controller = new(userService);
            IActionResult result = controller.Get(user.Id);
            OkObjectResult ok = result as OkObjectResult;           

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);            
        }

        [Fact]
        public async Task Should_Return_Valid_When_User_Created()
        {
            UserService userService = new();

            UserController controller = new(userService);

            Models.User user = new()
            {
                FirstName = "Test",
                LastName = "User",
                Age = 20
            };
            IActionResult result = controller.Create(user);

            OkResult ok = result as OkResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async Task Should_Return_Valid_When_User_Updated()
        {
            DatabaseContext database = new();
            Models.User user = new()
            {
                FirstName = "Test",
                LastName = "User",
                Age = 20
            };
            database.Users.Add(user);
            database.SaveChanges();

            UserService userService = new();

            UserController controller = new(userService);

            Models.User updatedUser = new()
            {
                Id = user.Id,
                FirstName = "Updated",
                LastName = "User",
                Age = 21
            };
            IActionResult result = controller.Update(updatedUser);

            OkResult ok = result as OkResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async Task Should_Return_Valid_When_User_Removed()
        {
            DatabaseContext database = new();
            Models.User user = new()
            {
                FirstName = "Test",
                LastName = "User",
                Age = 20
            };
            database.Users.Add(user);
            database.SaveChanges();

            UserService userService = new();

            UserController controller = new(userService);
            IActionResult result = controller.Delete(user.Id);

            OkResult ok = result as OkResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }
    }
}