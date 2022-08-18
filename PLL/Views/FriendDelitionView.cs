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
    public class FriendDelitionView
    {
        FriendService friendService = new FriendService();

        public void Show(User user)
        {            
            while (true)
            {

                var friendList = friendService.GetAllFriendsByUserId(user.Id).ToArray();

                if (friendList.Count() == 0)
                {
                    Console.WriteLine("\nВаш список друзей пуст! Некого удалять.\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nКакого друга вы хотите вы хотите удалить из своего списка друзей?\n");

                    Console.WriteLine(friendService.GetAllFriendsForChoosing(friendList));

                    int friendCount = friendList.Count();
                    FailureMessage.Show($"Вернуться в меню друзей (нажмите {friendCount + 1})");

                    var keyValue = int.Parse(Console.ReadLine());

                    if (keyValue == friendCount + 1) break;
                    
                    try
                    {
                        friendService.DeleteFriend(user.Id, friendList[keyValue - 1].FriendId);
                        SuccessMessage.Show("Пользователь удалён из списка друзей.");
                    }
                    catch (Exception)
                    {
                        FailureMessage.Show("Произошла ошибка при попытке удаления пользователя из друзей.");                       
                    }
                }
            }
        }
    }
}
