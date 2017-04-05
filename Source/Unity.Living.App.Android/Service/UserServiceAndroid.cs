using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Auth;
using Xamarin.Forms;
using Unity.Living.AppAndroid;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.AppAndroid.Helpers;

[assembly: Dependency(typeof(UserServiceAndroid))]
namespace Unity.Living.AppAndroid.Service
{

}
public class UserServiceAndroid : ServiceBaseAndroid, ILoginService
{
    public void StoreToken(string username, string name, string token)
    {
        var dict = new Dictionary<string, string> { { "Token", token }, { "Name", name } };
        Account account = new Account(username, dict);
        AccountStore.Create(Forms.Context).Save(account, "Unity");
    }

    public string GetToken(string username)
    {
        try
        {
            IEnumerable<Account> accounts = AccountStore.Create(Forms.Context).FindAccountsForService("Unity");
            if (accounts != null)
            {
                var selectedAccount = accounts.FirstOrDefault(a => a.Username == username);
                if (selectedAccount != null)
                {
                    var selectedKey = selectedAccount.Properties.FirstOrDefault(s => s.Key == "Token");
                    return selectedKey.Value;
                }
                else
                {
                    return "";
                }

            }
            else
            {
                return "";
            }
        }
        catch (Exception exception)
        {
            return "";
        }
    }

    public string GetUserName()
    {
        IEnumerable<Account> accounts = AccountStore.Create(Forms.Context).FindAccountsForService("Unity");
        if (accounts != null)
        {
            var selectedAccount = accounts.FirstOrDefault();
            if (selectedAccount != null)
            {
                var selectedKey = selectedAccount.Properties.FirstOrDefault(s => s.Key == "Name");
                return selectedKey.Value;
            }
            else
            {
                return "";
            }

        }
        else
        {
            return "";
        }

    }

    public void ClearToken(string username)
    {
        IEnumerable<Account> accounts = AccountStore.Create(Forms.Context).FindAccountsForService("Unity");
        if (accounts != null)
        {
            var selectedAccount = accounts.FirstOrDefault(a => a.Username == username);
            if (selectedAccount != null)
            {
                AccountStore.Create(Forms.Context).Delete(selectedAccount, "Unity");
            }
        }
    }

    public async Task<TokenModel> SignIn(SignInModel model)
    {
        var json = await PostAsyncWithoutAuth("login/", model);
        return JsonConvert.DeserializeObject<TokenModel>(json);
    }

    public async Task SaveUserData(string userData)
    {
        Settings.GeneralSettings = userData;
    }

    public string GetUserData()
    {
        return Settings.GeneralSettings;
    }

    public async Task SaveAppartment(string appartment)
    {
        SettingsAppartment.GeneralSettings = appartment;
    }

    public string GetAppartment()
    {
        return SettingsAppartment.GeneralSettings;
    }
}