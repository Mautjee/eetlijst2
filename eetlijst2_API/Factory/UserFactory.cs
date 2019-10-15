using System;
using Data.Contexts;
using Data.Repositories;
using Logic;

namespace Factory
{
    public class UserFactory
    {
        public static UserLogic useMemoryContext()
        {
            return new UserLogic(new UserRepository(new UserMemoryContext()));
        }
    }
}