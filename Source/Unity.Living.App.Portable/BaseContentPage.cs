using Acr.UserDialogs;
using Plugin.Connectivity;
using System;
using Unity.Living.App.Portable.Helpers;
using Xamarin.Forms;

namespace Unity.Living.App.Portable
{
    public class BaseContentPage: ContentPage
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
