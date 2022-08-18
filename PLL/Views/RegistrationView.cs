using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;

        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.WriteLine("\nДля создания нового профиля введите ваше имя:");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.WriteLine("Ваша фамилия:");
            userRegistrationData.LastName = Console.ReadLine();

            Console.WriteLine("Пароль:");
            userRegistrationData.Password = Console.ReadLine();

            Console.WriteLine("Почтовый адрес:");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                userService.Register(userRegistrationData);

                SuccessMessage.Show("\nВаш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.\n");
            }

            catch (ArgumentNullException)
            {
                FailureMessage.Show("\nВведите корректное значение.\n");
            }

            catch (Exception)
            {
                FailureMessage.Show("\nПроизошла ошибка при регистрации.\n");
            }
        }
    }
}