using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendListView
    {
        FriendService friendService = new FriendService();
        public void Show(User user)
        {
            var friendList = friendService.GetAllFriendsByUserId(user.Id);

            if (friendList.Count() == 0)
            {
                Console.WriteLine("Ваш список друзей пуст!");
            }
            else
            {
                InfoMessage.Show("Список ваших друзей.\n");
                foreach (var friend in friendList)
                {
                    var friendFirstnameLastnameEmail = friendService.GetFullDataAboutFriend(friend.FriendId);
                    Console.WriteLine($"{friendFirstnameLastnameEmail.FirstName} {friendFirstnameLastnameEmail.LastName} {friendFirstnameLastnameEmail.Email}");
                }
            }


        }
    }
}
