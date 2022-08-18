using NUnit.Framework;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Exceptions;

namespace SocialNetwork.Tests
{
    public class Tests
    {
        UserService userService = new UserService();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AuthenticationWithDataOfNonExistingUserMustThrowException()
        {
            var UserAuthenticationData = new UserAuthenticationData()
            {
                Email = "ikfewfiowefhjerfghrguiregrehgresigoigrh@gmail.com",
                Password = "wejfejwfweofijwefjiewofjweiofefaewf"
            };

            Assert.Throws<UserNotFoundException>(() => userService.Authenticate(UserAuthenticationData));
        }
    }
}