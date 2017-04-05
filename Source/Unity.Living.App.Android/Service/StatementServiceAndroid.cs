using Xamarin.Forms;
using Unity.Living.AppAndroid;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Living.App.Portable.Helpers;

[assembly: Dependency(typeof(StatementServiceAndroid))]
namespace Unity.Living.AppAndroid.Service
{ }
public class StatementServiceAndroid : ServiceBaseAndroid, IStatementService
{
    public async Task<StatementModel> GetStatement(int houseId)
    {
        var url = string.Format(UrlHelper.HouseAccountStatement, houseId);
        var json = await FetchAsync(url);
        var result = JsonConvert.DeserializeObject<StatementModel>(json);
        return result;
    }

    public async Task<DuesStatementModel> GetDuesStatement(int houseId)
    {
        var url = string.Format(UrlHelper.HouseDuesAccountStatement, houseId);
        var json = await FetchAsync(url);
        var result = JsonConvert.DeserializeObject<DuesStatementModel>(json);
        return result;
    }

    public async Task<AdvanceStatementModel> GetAdvanceStatement(int houseId)
    {
        var url = string.Format(UrlHelper.HouseAdvanceAccountStatement, houseId);
        var json = await FetchAsync(url);
        var result = JsonConvert.DeserializeObject<AdvanceStatementModel>(json);
        return result;
    }   

}
