using Acr.UserDialogs;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Living.App.Portable.Helpers;
using Xamarin.Forms;

namespace Unity.Living.App.Portable
{
    public class BaseTabbedPage : TabbedPage
    {
        protected void IfConnected(Action action)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                action();
            }
            else
            {
                UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
        }
        IProgressDialog _busy;
        protected void ShowBusy(string message)
        {
            if (_busy == null)
            {
                _busy = UserDialogs.Instance.Loading(message);
            }
            else if (!_busy.IsShowing)
            {
                _busy.Show();
            }
        }
        protected void HideBusy()
        {
            if (_busy != null)
            {
                _busy.Hide();
            }
        }
    }
}
