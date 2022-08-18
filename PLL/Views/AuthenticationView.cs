using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AuthenticationView
    {
        UserService userService;

        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("\nВведите почтовый адрес:");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("\nВведите пароль:");
            authenticationData.Password = Console.ReadLine();

            try
            {
                var user = userService.Authenticate(authenticationData);

                SuccessMessage.Show("\nВы успешно вошли в социальную сеть!");
                SuccessMessage.Show("Добро пожаловать " + user.FirstName + "\n");


                Program.userMenuView.Show(user);
            }

            catch (WrongPasswordException)
            {
                FailureMessage.Show("\nПароль не корректный!\n");
            }

            catch (UserNotFoundException)
            {
                FailureMessage.Show("\nПользователь не найден!\n");
            }
        }
    }
}
