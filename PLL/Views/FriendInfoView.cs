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
    public class FriendInfoView
    {
        FriendService friendService = new FriendService();
        public void Show(User user)
        {
            var friendList = friendService.GetAllFriendsByUserId(user.Id).ToArray();

            if (friendList.Count() == 0)
            {
                Console.WriteLine("\nВаш список друзей пуст!\n");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("\nО каком друге вы хотите просмотреть информацию?.\n");

                    Console.WriteLine(friendService.GetAllFriendsForChoosing(friendList));

                    int friendCount = friendList.Count();
                    FailureMessage.Show($"Вернуться в меню друзей (нажмите {friendCount + 1})");

                    var keyValue = int.Parse(Console.ReadLine());

                    if (keyValue == friendCount + 1) break;

                    string friendInfo = friendService.GetFullDataAboutFriendAsString(friendList[keyValue - 1].FriendId);

                    Console.WriteLine(friendInfo);                    
                };                
            }
        }
    }
}
