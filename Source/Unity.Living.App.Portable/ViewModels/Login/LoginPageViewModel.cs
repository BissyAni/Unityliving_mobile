using System.Collections.Generic;
using System.Linq;
using Android.Widget;
using Unity.Living.App.Portable.Models.Apartment;
using Unity.Living.App.Portable.Service;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly ApartmentService service;
        private List<ApartmentModel> _apartmentNames=new List<ApartmentModel>();
        private ApartmentModel _apartmentSelected;
        private bool _frameVisibility = false;
        private double _listHeight;
        private bool _entryFocused;
        private string _apartmentName=string.Empty;
        private bool _searchBarVisibility=false;
        private bool _entryVisibility=true;

        private List<ApartmentModel> getFilteredResult(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                return _apartmentNames.Where(c => c.Name.ToUpper().Contains(searchText.ToUpper())).ToList();
            }
            return null;
        }
        private void SetFrameProperties(List<ApartmentModel> result)
        {
            if (result != null && result.Count > 0)
            {
                FrameVisibility = true;
                ListHeight = result.Count * 60;
            }
            else
            {
                FrameVisibility = false;
            }
        }
        public List<ApartmentModel> filteredList(string searchText)
        {
            var result = getFilteredResult(searchText);
            SetFrameProperties(result);
            return result;
        }
        public bool FrameVisibility

        {
            get { return _frameVisibility; }
            set
            {
                _frameVisibility = value;
                OnPropertyChanged("FrameVisibility");
            }
        }

        public bool SearchBarVisibility
        {
            get { return _searchBarVisibility; }
            set
            {
                _searchBarVisibility = value;
                OnPropertyChanged("SearchBarVisibility");
            }
        }

        public double ListHeight
        {
            get { return _listHeight; }
            set
            {
                _listHeight = value;
                OnPropertyChanged("ListHeight");
            }
        }

        public LoginPageViewModel()
        {
            service = new ApartmentService();
            _apartmentNames = service.GetApartments().Result;
        }
        public bool EntryFocused
        {
            get
            {
                return _entryFocused;
                
            }
            set
            {
                _entryFocused = value;
                OnPropertyChanged("EntryFocused");
            }
        }

        public bool EntryVisibility
        {
            get { return _entryVisibility; }
            set
            {
                _entryVisibility = value;
                OnPropertyChanged("EntryVisibility");
            }
        }

        public string ApartmentName

        {
            get { return _apartmentName; }
            set
            {
                _apartmentName = value;
                OnPropertyChanged("ApartmentName");
            }
        }
    }
}
