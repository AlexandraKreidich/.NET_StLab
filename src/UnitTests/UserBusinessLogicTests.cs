using BusinessLayer.Contracts;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAcessLayer.Contracts;
using DataAcessLayer.Models.DataTransferObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class UserBusinessLogicTest
    {
        [TestMethod]
        public void UserService_Register_returns_correct_UserModel()
        {
            // Arrange
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(ur => ur.Register(It.IsAny<UserReq>()))
                .Returns<UserReq>((userReq) => int.MinValue);

            IUserService userService = new UserService(userRepositoryMock.Object);

            RegisterUserModel registerModel = new RegisterUserModel("test@mail.ru", "Alexandra", "LastName", "password");

            // Act
            UserModel result = userService.Register(registerModel);

            // Assert
            result.Id.Should().Be(int.MinValue);
            result.FirstName.Should().Be(registerModel.FirstName);
        }
    }
}
