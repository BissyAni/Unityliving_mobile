using System;

namespace Unity.Living.App.Portable.ViewModels
{
    public class CommentOrMessageViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public DateTime LastUpdate { get; set; }
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set
            {
                createdDate = value;
                OnPropertyChanged("CreatedDate");

            }
        }
        private string createdBy;

        public string CreatedBy
        {
            get { return createdBy; }
            set
            {
                createdBy = value;
                OnPropertyChanged("CreatedBy");
            }
        }

    }
}
