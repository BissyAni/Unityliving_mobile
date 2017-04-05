using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.Living.App.Portable.Models.DuesModel;
using Unity.Living.App.Portable.ViewModels;

namespace Unity.Living.App.Portable.Models.DuesModels
{
    public class DuesModel
    {
        [JsonProperty(PropertyName = "advance")]
        public double Advance { get; set; }
        [JsonProperty(PropertyName = "chargeItemObject")]
        public object ChargeItemObject { get; set; }
        [JsonProperty(PropertyName = "credits_list")]
        public List<object> CreditsList { get; set; }
        [JsonProperty(PropertyName = "payment_category")]
        public string PaymentCategory { get; set; }
        [JsonProperty(PropertyName = "total_dues")]
        public double TotalDues { get; set; }
        [JsonProperty(PropertyName = "bln_hide_chkbox")]
        public bool BlnHideCheckbox { get; set; }
        [JsonProperty(PropertyName = "lst_group_charge_batch")]
        public List<LstGroupChargeBatch> LstGroupChargeBatch { get; set; }
        [JsonProperty(PropertyName = "over_due")]
        public double OverDue { get; set; }
        [JsonProperty(PropertyName = "payment_integrated_site")]
        public List<PaymentIntegratedSite> PaymentIntegratedSite { get; set; }
        [JsonProperty(PropertyName = "group_count")]
        public GroupCount GroupCount { get; set; }
        [JsonProperty(PropertyName = "group_dues_list")]
        public List<GroupDuesList> GroupDuesList { get; set; }
        [JsonProperty(PropertyName = "dues_list")]
        public List<DuesList> DuesList { get; set; }
        [JsonProperty(PropertyName = "house")]
        public HouseData House { get; set; }
    }
}
