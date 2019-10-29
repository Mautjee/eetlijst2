using System;
using Model;
namespace Data.Interfaces
{
    public interface IAccountContext
    {
        Account getAccountById(int id);
    }
}
