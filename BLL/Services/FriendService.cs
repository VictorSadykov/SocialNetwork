using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository = new FriendRepository();
        IUserRepository userRepository = new UserRepository();

        public IEnumerable<Friend> GetAllFriendsByUserId(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(friend =>
            {
                friends.Add(new Friend(userId, friend.friend_id));
            });

            return friends;
        }

        public string GetAllFriendsForChoosing(IEnumerable<Friend> friendList)
        {
            string output = null;
            int counter = 1;

            foreach (var friend in friendList)
            {
                var friendFirstnameLastnameEmail = GetFullDataAboutFriend(friend.FriendId);

                output += ($"{friendFirstnameLastnameEmail.FirstName} {friendFirstnameLastnameEmail.LastName} {friendFirstnameLastnameEmail.Email} (нажмите {counter})\n");

                counter++;
            }

            return output;
        }

        public void DeleteFriend(int userId, int friendId)
        {
            var foundUserEntity = userRepository.FindById(friendId);
            if (foundUserEntity == null) throw new UserNotFoundException();

            if (friendRepository.Delete(userId, friendId) == 0 || friendRepository.Delete(friendId, userId) == 0) throw new Exception(); 
        }

        public void Add(FriendToAddData friendToAddData)
        {
            var foundUserEntity = userRepository.FindByEmail(friendToAddData.FriendEmail);
            if (foundUserEntity == null) throw new UserNotFoundException();

            var friendList = friendRepository.FindAllByUserId(friendToAddData.UserId);

            foreach (var friend in friendList)
            {
                if (friend.friend_id == foundUserEntity.id) throw new FriendAlreadyAddedException();
            }

            var friendRecipientEntity = new FriendEntity()
            {
                user_id = friendToAddData.UserId,
                friend_id = foundUserEntity.id
            };            

            var friendSenderEntity = new FriendEntity()
            {
                user_id = foundUserEntity.id,
                friend_id = friendToAddData.UserId
            };

            if (friendRepository.Create(friendRecipientEntity) == 0 || friendRepository.Create(friendSenderEntity) == 0) throw new Exception();
            
        }

        public string GetFullDataAboutFriendAsString(int friendId)
        {
            FriendFullData friendFullData = GetFullDataAboutFriend(friendId);
            string output = "\n";

            foreach (var property in friendFullData.GetType().GetProperties())
            {
                var propertyValue = (property.GetValue(friendFullData) == null) ? "пользователь пока не заполнил данную информацию" : property.GetValue(friendFullData);
                switch (property.Name)
                {
                    case "FirstName":
                        output += $"Имя: {propertyValue}\n";
                        break;
                    case "LastName":
                        output += $"Фамилия: {propertyValue}\n";
                        break;
                    case "Email":
                        output += $"Адрес электронной почты: {propertyValue}\n";
                        break;
                    case "Photo":
                        output += $"Ссылка на фото: {propertyValue}\n";
                        break;
                    case "FavoriteMovie":
                        output += $"Любимый фильм: {propertyValue}\n";
                        break;
                    case "FavoriteBook":
                        output += $"Любимая книга: {propertyValue}\n";
                        break;
                    default:
                        break;
                }
            }

            return output;
        }

        public FriendFullData GetFullDataAboutFriend(int friendId)
        {
            UserEntity userToFind = userRepository.FindById(friendId);

            var frientFullData = new FriendFullData()
            {
                FirstName = userToFind.firstname,
                LastName = userToFind.lastname,
                Email = userToFind.email,
                Photo = userToFind.photo,
                FavoriteBook = userToFind.favorite_book,
                FavoriteMovie = userToFind.favorite_movie,
            };

            return frientFullData;
        }
    }
}
