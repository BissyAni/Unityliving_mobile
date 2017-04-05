using Newtonsoft.Json;
using System.Threading.Tasks;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.ViewModels;
using Unity.Living.AppAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(UserOverviewAndroid))]
namespace Unity.Living.AppAndroid.Service
{ }
public class UserOverviewAndroid : ServiceBaseAndroid, IUserOverview
{
    public async Task<OverViewModel> GetOverView()
    {
        var json =await FetchAsync(UrlHelper.Overview);
        return JsonConvert.DeserializeObject<OverViewModel>(json);
    }

    public async Task<HouseTenantandOwnerViewmodel> GetUserHouseDetails(int id)
    {
        var url = string.Format(UrlHelper.HouseView, id);
        var json = await FetchAsync(url);
        return JsonConvert.DeserializeObject<HouseTenantandOwnerViewmodel>(json);
    }

    public string GetVersion()
    {
        var context = Forms.Context;
        string versionName = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
        return versionName;
    }

    public async Task<bool> EditUserHouseDetails(int id, UserDetailsHouseModel userhousedetails)
    {
        var url = string.Format(UrlHelper.EditHouse, id);
        var result = await PutAsync<UserDetailsHouse>(url, userhousedetails.House);
        if (result == "{\"success\":true}")
            return true;
        else
            return false;
    }
    
    public async Task<bool> EditUserOwnerDetails(int id, UserDetailsOwnerModel userOwnerdetails)
    {
        var url = string.Format(UrlHelper.EditOwner, id);
        var result = await PutAsync<UserDetailsOwner>(url, userOwnerdetails.House);
        if (result == "{\"success\":true}")
            return true;
        else
            return false;
    }

    public async Task<bool> EditUserTenentDetails(int id, UserDetailsTenentModel userTenentdetails)
    {
        var url = string.Format(UrlHelper.EditTenant, id);
        var result = await PutAsync<UserDetailsTenent>(url, userTenentdetails.House);
        if (result == "{\"success\":true}")
            return true;
        else
            return false;
    }

    public async Task<GetUserDetailsEditModel> GetTenentEditDetails(int id)
    {
        var url = string.Format(UrlHelper.EditTenant, id);
        var json = await FetchAsync(url);
        return JsonConvert.DeserializeObject<GetUserDetailsEditModel>(json);
    }

    public async Task<GetUserDetailsEditModel> GetHouseEditDetails(int id)
    {
        var url = string.Format(UrlHelper.EditHouse, id);
        var json = await FetchAsync(url);
        return JsonConvert.DeserializeObject<GetUserDetailsEditModel>(json);
    }
    
    public async Task<GetUserDetailsEditModel> GetOwnerEditDetails(int id)
    {
        var url = string.Format(UrlHelper.EditOwner, id);
        var json = await FetchAsync(url);
        return JsonConvert.DeserializeObject<GetUserDetailsEditModel>(json);     
    }

    public int GetCurrentUserId()
    {
        return GetUserId();
    }

    public async Task<UserDetailsModel> GetUserDetails(int id)
    {
        var url = string.Format(UrlHelper.UserDetails + id);
        var json = await FetchAsync(url);
        var result = JsonConvert.DeserializeObject<UserDetailsModel>(json);
        return result;
    }
    
    public async Task<string> ChangePassword(ChangePasswordModel changePass)
    {      
        var json = await PostAsyncCustom<ChangePasswordModel>(UrlHelper.ChangePassword, changePass);
        if (json == "{\"success\":\"true\"}")
        {
            return "success";
        }
        else
        {
            return json;
        }
    }

}
