﻿using ClassifiedAds.Application;
using ClassifiedAds.Services.Identity.Entities;
using ClassifiedAds.Services.Identity.Repositories;

namespace ClassifiedAds.Services.Identity.Commands.Users
{
    public class DeleteRoleCommand : ICommand
    {
        public User User { get; set; }
        public UserRole Role { get; set; }
    }

    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(DeleteRoleCommand command)
        {
            command.User.UserRoles.Remove(command.Role);
            _userRepository.AddOrUpdate(command.User);
            _userRepository.UnitOfWork.SaveChanges();
        }
    }
}
