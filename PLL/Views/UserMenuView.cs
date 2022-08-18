using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Linq;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        UserService userService;

        public UserMenuView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                InfoMessage.Show($"\nВходящие сообщения: {user.IncomingMessages.Count()}");
                InfoMessage.Show($"Исходящие сообщения: {user.OutgoingMessages.Count()}\n");

                Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Перейти в меню друзей (нажмите 3)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Просмотреть входящие сообщения (нажмите 5)");
                Console.WriteLine("Просмотреть исходящие сообщения (нажмите 6)");
                FailureMessage.Show("Выйти из профиля (нажмите 7)");

                string keyValue = Console.ReadLine();

                if (keyValue == "7") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.userInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program.userDataUpdateView.Show(user);
                            break;
                        }
                    case "3":
                        {
                            Program.friendMenuView.Show(user);
                            break;
                        }
                    case "4":
                        {
                            Program.messageSendingView.Show(user);
                            break;
                        }

                    case "5":
                        {

                            Program.userIncomingMessageView.Show(user.IncomingMessages);
                            break;
                        }

                    case "6":
                        {
                            Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                            break;
                        }
                }
            }
        }
    }
}