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
    public class FriendAdditionView
    {
        FriendService friendService = new FriendService();

        public void Show(User user)
        {
            var friendToAddData = new FriendToAddData();

            Console.Write("Введите почтовый адрес друга: ");
            friendToAddData.FriendEmail = Console.ReadLine();
            friendToAddData.UserId = user.Id;

            try
            {
                friendService.Add(friendToAddData);
                SuccessMessage.Show("\nДруг успешно добавлен!\n");
            }
            catch (UserNotFoundException)
            {
                FailureMessage.Show("\nПользователь не найден!\n");
            }
            catch (FriendAlreadyAddedException)
            {
                FailureMessage.Show("\nПользователь уже находится в вашем списке друзей!\n");
            }
            catch (Exception)
            {
                FailureMessage.Show("\nПроизошла ошибка при попытке добавить пользователя в друзья.\n");
            }
        }
    }
}
