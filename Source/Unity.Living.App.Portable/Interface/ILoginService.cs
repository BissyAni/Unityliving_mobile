using System.Threading.Tasks;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Models.Apartment;

namespace Unity.Living.App.Portable.Interface
{
    public interface ILoginService
    {
        void StoreToken(string username, string name, string token);
        string GetToken(string username);
        void ClearToken(string username);
        string GetUserName();
        Task<TokenModel> SignIn(SignInModel model);
        Task SaveUserData(string userData);
        string GetUserData();
        Task  SaveAppartment(string appartment);
        string GetAppartment();
    }
}
