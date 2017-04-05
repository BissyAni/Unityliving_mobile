using System;
using System.Collections.Generic;
using Unity.Living.App.Portable.ViewModels;

namespace Unity.Living.App.Portable.Models
{
    public class ServiceModel
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public int HouseID { get; set; }
        public string HouseName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime PreferredDate { get; set; }
        public string Content { get; set; }
        public DateTime PreferredTime { get; set; }
        public string Status { get; set; }
        public DateTime? CloseDate { get; set; }
        public List<CommentOrMessageViewModel> CommentOrMessageViewModels { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
