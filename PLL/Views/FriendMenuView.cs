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
    public class FriendMenuView
    {
        UserService userService = new UserService();
        FriendService friendService = new FriendService();

        public void Show(User user)
        {
            while (true)
            {
                InfoMessage.Show("Количество друзей: " + friendService.GetAllFriendsByUserId(user.Id).Count() + "\n");
                Console.WriteLine("Показать список друзей (нажмите 1)");
                Console.WriteLine("Просмотреть информацию о друге (нажмите 2)");
                Console.WriteLine("Добавить в друзья (нажмите 3)");
                Console.WriteLine("Удалить из друзей (нажмите 4)");
                FailureMessage.Show("Перейти в меню пользователя (нажмите 5)");

                string keyValue = Console.ReadLine();
                if (keyValue == "5") break;

                switch (keyValue)
                {
                    case "1":
                        Program.friendListView.Show(user);
                        break;
                    case "2":
                        Program.friendInfoView.Show(user);
                        break;
                    case "3":
                        Program.friendAdditionView.Show(user);
                        break;
                    case "4":
                        Program.friendDelitionView.Show(user);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
