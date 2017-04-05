using Unity.Living.App.Portable.Service;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Owner
{
    public partial class UserDetailsOwnerDetailsEdit : BaseContentPage
    {
        UserService userDetailsService = new UserService();
        public UserDetailsOwnerDetailsEdit(int id)
        {
            IfConnected(() =>
            {
                var bindingResult = userDetailsService.GetUserDetails(id);
                BindingContext = bindingResult.Result;
            });
        }
    }
}
