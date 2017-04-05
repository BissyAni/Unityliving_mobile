using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Plugin.Connectivity;
using Acr.UserDialogs;
using Unity.Living.App.Portable.Helpers;

namespace Unity.Living.App.Portable
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
        }
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

        private string title = string.Empty;
        public const string TitlePropertyName = "Title";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        private string subtitle = string.Empty;
        public const string SubtitlePropertyName = "Subtitle";
        public string Subtitle
        {
            get { return subtitle; }
            set { SetProperty(ref subtitle, value); }
        }

        private string icon = null;
        public const string IconPropertyName = "Icon";
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (SetProperty(ref isBusy, value))
                    IsNotBusy = !isBusy;
            }
        }

        bool isNotBusy = true;
        public bool IsNotBusy
        {
            get { return isNotBusy; }
            private set { SetProperty(ref isNotBusy, value); }
        }
        private bool canLoadMore = true;
        public const string CanLoadMorePropertyName = "CanLoadMore";
        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { SetProperty(ref canLoadMore, value); }
        }
        protected bool SetProperty<T>(
            ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
            {
                if (EqualityComparer<T>.Default.Equals(backingStore, value))
                    return false;

                backingStore = value;

                if (onChanged != null)
                    onChanged();

                OnPropertyChanged(propertyName);
                return true;
            }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

