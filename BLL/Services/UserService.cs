﻿using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class UserService
    {
        IUserRepository userRepository = new UserRepository();
        MessageService messageService = new MessageService();
        

        public void Register(UserRegistrationData userRegistrationData)
        {
            
            if (string.IsNullOrEmpty(userRegistrationData.FirstName)) throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.LastName)) throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.Email)) throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.Password)) throw new ArgumentNullException();

            if (userRegistrationData.Password.Length < 8) throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email)) throw new ArgumentNullException();

            if (userRepository.FindByEmail(userRegistrationData.Email) != null) throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            if (userRepository.Create(userEntity) == 0) throw new Exception();

        }

        public User FindById(int id)
        {
            var findUserEntity = userRepository.FindById(id);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var foundUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);

            if (foundUserEntity == null) throw new UserNotFoundException();

            if (foundUserEntity.password != userAuthenticationData.Password) throw new WrongPasswordException();

            return ConstructUserModel(foundUserEntity);
        }

        public User FindByEmail(string email)
        {
            var foundUserEntity = userRepository.FindByEmail(email);

            if (foundUserEntity == null) throw new UserNotFoundException();

            return ConstructUserModel(foundUserEntity);
        }

        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };

            if(userRepository.Update(updatableUserEntity) == 0) throw new Exception();
        }

        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessages = messageService.GetIncomingMessagesByUserId(userEntity.id);
            var outcomingMessages = messageService.GetOutcomingMessagesByUserId(userEntity.id);

            return new User(userEntity.id,
                userEntity.firstname,
                userEntity.lastname,
                userEntity.password,
                userEntity.email,
                userEntity.photo,
                userEntity.favorite_movie,
                userEntity.favorite_book,
                incomingMessages,
                outcomingMessages);
        }
    }
}
