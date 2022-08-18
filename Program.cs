using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    
    internal class Program
    {
        public static MessageService messageService = new MessageService();
        public static UserService userService = new UserService();
        public static MainView mainView = new MainView();
        public static RegistrationView registrationView = new RegistrationView(userService);
        public static AuthenticationView authenticationView = new AuthenticationView(userService);
        public static UserMenuView userMenuView = new UserMenuView(userService);
        public static UserInfoView userInfoView = new UserInfoView();
        public static UserDataUpdateView userDataUpdateView = new UserDataUpdateView(userService);
        public static MessageSendingView messageSendingView = new MessageSendingView(messageService, userService);
        public static UserIncomingMessageView userIncomingMessageView = new UserIncomingMessageView();
        public static UserOutcomingMessageView userOutcomingMessageView = new UserOutcomingMessageView();
        public static FriendMenuView friendMenuView = new FriendMenuView();
        public static FriendAdditionView friendAdditionView = new FriendAdditionView();
        public static FriendListView friendListView = new FriendListView();
        public static FriendInfoView friendInfoView = new FriendInfoView();
        public static FriendDelitionView friendDelitionView = new FriendDelitionView();


        static void Main(string[] args)
        {
            while (true)
            {
                mainView.Show();
            }
        }
    }
}
