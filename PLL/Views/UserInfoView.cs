using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;
using System;
namespace SocialNetwork.PLL.Views
{
    public class UserInfoView
    {
        public void Show(User user)
        {
            InfoMessage.Show("\nИнформация о моем профиле\n");
            Console.WriteLine("Мой идентификатор: {0}", user.Id);
            Console.WriteLine("Меня зовут: {0}", user.FirstName);
            Console.WriteLine("Моя фамилия: {0}", user.LastName);
            Console.WriteLine("Мой пароль: {0}", user.Password);
            Console.WriteLine("Мой почтовый адрес: {0}", user.Email);
            Console.WriteLine("Ссылка на моё фото: {0}", user.Photo);
            Console.WriteLine("Мой любимый фильм: {0}", user.FavoriteMovie);
            Console.WriteLine("Моя любимая книга: {0}\n", user.FavoriteBook);
        }
    }
}