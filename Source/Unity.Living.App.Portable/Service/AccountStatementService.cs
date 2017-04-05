using System.Threading.Tasks;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Service
{
    public class AccountStatementService
    {      
        public async Task<StatementModel> GetAllService(int houseId)
        {
            var service = DependencyService.Get<IStatementService>();
            var result = await service.GetStatement(houseId);
            return result;
        }
    }
}
