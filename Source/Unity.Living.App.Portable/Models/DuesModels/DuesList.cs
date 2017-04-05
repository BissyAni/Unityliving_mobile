using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.DuesModels
{
    public class DuesList
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "number")]
        public object Number { get; set; }
        [JsonProperty(PropertyName = "group_bill_number")]
        public object GroupBillNumber { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }
        [JsonProperty(PropertyName = "due_date")]
        public string DueDate { get; set; }
        [JsonProperty(PropertyName = "settle_from_advance")]
        public bool SettleFromAdvance { get; set; }
        [JsonProperty(PropertyName = "fine_process_count")]
        public int? FineProcessCount { get; set; }
        [JsonProperty(PropertyName = "last_fine_process_date")]
        public object LastFineProcessDate { get; set; }
        [JsonProperty(PropertyName = "next_fine_process_date")]
        public string NextFineProcessDate { get; set; }
        [JsonProperty(PropertyName = "fine")]
        public bool Fine { get; set; }
        [JsonProperty(PropertyName = "settled_amount")]
        public string SettledAmount { get; set; }
        [JsonProperty(PropertyName = "service_tax")]
        public bool ServiceTax { get; set; }
        [JsonProperty(PropertyName = "balance")]
        public string Balance { get; set; }
        [JsonProperty(PropertyName = "comment")]
        public object Comment { get; set; }
        [JsonProperty(PropertyName = "sys_gen")]
        public bool SysGen { get; set; }
        [JsonProperty(PropertyName = "prev_year")]
        public bool PreviousYear { get; set; }
        [JsonProperty(PropertyName = "created_user")]
        public object CreatedUser { get; set; }
        [JsonProperty(PropertyName = "house")]
        public int House { get; set; }
        [JsonProperty(PropertyName = "charge_account")]
        public int ChargeAccount { get; set; }
        [JsonProperty(PropertyName = "fine_setting")]
        public int? FineSetting { get; set; }
        [JsonProperty(PropertyName = "fine_origin")]
        public object FineOrigin { get; set; }
        [JsonProperty(PropertyName = "fine_group_origin")]
        public object FineGroupOrigin { get; set; }
        [JsonProperty(PropertyName = "charge_batch")]
        public int? ChargeBatch { get; set; }
        [JsonProperty(PropertyName = "group_charge_batch")]
        public object GroupChargeBatch { get; set; }
        [JsonProperty(PropertyName = "tax_origin")]
        public object TaxOrigin { get; set; }
        [JsonProperty(PropertyName = "charge_setting")]
        public object ChargeSetting { get; set; }
        [JsonProperty(PropertyName = "group_charge_setting")]
        public object GroupChargeSetting { get; set; }
        [JsonProperty(PropertyName = "service_tax_head")]
        public object ServiceTaxHead { get; set; }
        [JsonProperty(PropertyName = "cess_origin")]
        public object CessOrigin { get; set; }
        [JsonProperty(PropertyName = "site")]
        public int? Site { get; set; }
    }
}
