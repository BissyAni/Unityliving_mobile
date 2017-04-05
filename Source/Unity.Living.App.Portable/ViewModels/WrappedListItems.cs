using System.ComponentModel;

namespace Unity.Living.App.Portable.ViewModels
{
    public class WrappedListItems<T> : INotifyPropertyChanged
    {
        public T Item { get; set; }
        bool isChecked = false;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
                }
            }
        }
        private bool unChecked = true;
        public bool UnChecked
        {
            get
            {
                return unChecked;
            }
            set
            {
                if (unChecked != value)
                {
                    unChecked = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("UnChecked"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }

}
