using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models.SettleDue
{
    public class Credits
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }
        [JsonProperty(PropertyName = "settled_amount")]
        public string SettledAmount { get; set; }
        [JsonProperty(PropertyName = "balance")]
        public string Balance { get; set; }
        [JsonProperty(PropertyName = "comment")]
        public object Comment { get; set; }
        [JsonProperty(PropertyName = "created_user")]
        public object CreatedUser { get; set; }
        [JsonProperty(PropertyName = "house")]
        public int House { get; set; }
        [JsonProperty(PropertyName = "credit_account")]
        public int CreditAccount { get; set; }
        [JsonProperty(PropertyName = "credit_group_origin")]
        public int CreditGroupOrigin { get; set; }
        [JsonProperty(PropertyName = "group_charge_batch")]
        public int GroupChargeBatch { get; set; }
        [JsonProperty(PropertyName = "site")]
        public int Site { get; set; }
    }
}
