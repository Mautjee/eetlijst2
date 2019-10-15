using Data.Contexts;
using Data.Repositories;
using Logic;

namespace Factory
{
    public class StrudenthouseFactory
    {
        public static StudenthouseLogic StudenthouseLogic()
        {
            return new StudenthouseLogic(new StudenthouseRepository(new StudenthouseMemoryContext()));
        }
    }
}