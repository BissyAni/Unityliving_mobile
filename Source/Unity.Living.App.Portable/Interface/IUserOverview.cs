using System.Threading.Tasks;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.ViewModels;

namespace Unity.Living.App.Portable.Interface
{
    public interface IUserOverview
    {
        Task<OverViewModel> GetOverView();
        Task<HouseTenantandOwnerViewmodel> GetUserHouseDetails(int id);
        Task<bool> EditUserHouseDetails(int id, UserDetailsHouseModel userhousedetails);
        Task<bool> EditUserOwnerDetails(int id, UserDetailsOwnerModel userOwnerdetails);
        Task<bool> EditUserTenentDetails(int id, UserDetailsTenentModel userTenentdetails);
        Task<GetUserDetailsEditModel> GetTenentEditDetails(int id);
        Task<GetUserDetailsEditModel> GetHouseEditDetails(int id);
        Task<GetUserDetailsEditModel> GetOwnerEditDetails(int id);
        int GetCurrentUserId();
        string GetVersion();        
        Task<UserDetailsModel> GetUserDetails(int id);
        Task<string> ChangePassword(ChangePasswordModel changePass);
    }
}
