using System.Threading.Tasks;
using Model;

namespace eetlijst2.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(Account account);
    }
}