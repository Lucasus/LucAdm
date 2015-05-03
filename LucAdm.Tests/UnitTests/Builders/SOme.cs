﻿using NSubstitute;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LucAdm.Tests
{
    public static class Some
    {
        public static CreateUserCommandBuilder CreateUserCommand()
        {
            return new CreateUserCommandBuilder().Create();
        }

        public static UserBuilder User()
        {
            return new UserBuilder().Create();
        }

        public static UserService UserService(PersistenceContext context = null, Repository<User> repository = null)
        {
            context = context ?? Context().With(new List<User>());
            return new UserService(repository ?? new Repository<User>(context), new UserQueryService(context), new UnitOfWorkFactory(context));
        }

        public static PersistenceContextBuilder Context()
        {
            return new PersistenceContextBuilder().Create();
        }
    }
}