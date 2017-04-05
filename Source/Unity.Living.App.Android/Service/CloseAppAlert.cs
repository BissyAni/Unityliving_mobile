using System;
using Unity.Living.App.Portable.Interface;
using Unity.Living.AppAndroid.Service;

[assembly: Xamarin.Forms.Dependency(typeof(CloseAppAlert))]
namespace Unity.Living.AppAndroid.Service
{
    public class CloseAppAlert : ICloseAppAlert
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}