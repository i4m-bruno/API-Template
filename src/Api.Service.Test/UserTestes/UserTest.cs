using System;
using System.Collections.Generic;
using API.Domain.Dtos.User;

namespace Api.Service.Test.UserTestes
{
    public class UserTest
    {
        public static string Name { get; set; }
        public static string Email { get; set; }
        public static string NewName { get; set; }
        public static string NewEmail { get; set; }
        public static Guid UserId { get; set; }

        public List<UserDto> UserDtoList = new List<UserDto>();
        public UserDto UserDto;
        public UserDtoCreate UserDtoCreate;
        public UserDtoCreateResult UserDtoCreateResult;
        public UserDtoUpdate UserDtoUpdate;
        public UserDtoUpdateResult UserDtoUpdateResult;

        public UserTest()
        {
            UserId = Guid.NewGuid();
            Name = Faker.Name.FullName();
            Email = Faker.Internet.Email();
            NewName = Faker.Name.FullName();
            NewEmail = Faker.Internet.Email();

            for (int i = 0; i < 6; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                UserDtoList.Add(dto);
            }

            UserDto = new UserDto()
            {
                Id = UserId,
                Nome = Name,
                Email = Email,
                CreateAt = DateTime.UtcNow
            };

            UserDtoCreate = new UserDtoCreate()
            {
                Email = Email,
                Nome = Name
            };

            UserDtoCreateResult = new UserDtoCreateResult()
            {
                Id = UserId,
                Email = Email,
                Nome = Name,
                CreateAt = DateTime.UtcNow
            };

            UserDtoUpdate = new UserDtoUpdate()
            {
                Id = UserId,
                Email = NewEmail,
                Nome = NewName
            };

            UserDtoUpdateResult = new UserDtoUpdateResult()
            {
                Id = UserId,
                Email = NewEmail,
                Nome = NewName,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
