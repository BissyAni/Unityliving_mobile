using System.Threading.Tasks;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Models.DuesModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Service
{
    public class DueService
    {
        public async Task<DuesModel> GetAllCharges(int houseId)
        {         
            var service = DependencyService.Get<IDueService>();
            var result = await service.GetDues(houseId);
            return result;
        }
    }
}
