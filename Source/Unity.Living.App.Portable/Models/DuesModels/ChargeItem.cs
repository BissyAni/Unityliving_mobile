using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.DuesModels
{
    public class ChargeItem
    {
        [JsonProperty(PropertyName = "comment")]
        public object Comment { get; set; }
        [JsonProperty(PropertyName = "due_date")]
        public string DueDate { get; set; }
        [JsonProperty(PropertyName = "settle_from_advance")]
        public bool SettleFromAdvance { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "house")]
        public string House { get; set; }
        [JsonProperty(PropertyName = "service_tax_head")]
        public object ServiceTaxHead { get; set; }
        [JsonProperty(PropertyName = "charge_setting")]
        public object ChargeSetting { get; set; }
        [JsonProperty(PropertyName = "number")]
        public object Number { get; set; }
        [JsonProperty(PropertyName = "site")]
        public string Site { get; set; }
        [JsonProperty(PropertyName = "fine_process_count")]
        public int FineProcessCount { get; set; }
        [JsonProperty(PropertyName = "cess_origin")]
        public object CessOrigin { get; set; }
        [JsonProperty(PropertyName = "created_user")]
        public object CreatedUser { get; set; }
        [JsonProperty(PropertyName = "fine_setting")]
        public string FineSetting { get; set; }
        [JsonProperty(PropertyName = "last_fine_process_date")]
        public object LastFineProcessDate { get; set; }
        [JsonProperty(PropertyName = "group_charge_batch_bill_id")]
        public int? GroupChargeBatchBillId { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "group_charge_setting_id")]
        public int? GroupChargeSettingId { get; set; }
        [JsonProperty(PropertyName = "tax_origin")]
        public object TaxOrigin { get; set; }
        [JsonProperty(PropertyName = "fine")]
        public bool Fine { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "fine_origin")]
        public object FineOrigin { get; set; }
        [JsonProperty(PropertyName = "prev_year")]
        public bool PreviousYear { get; set; }
        [JsonProperty(PropertyName = "service_tax")]
        public bool ServiceTax { get; set; }
        [JsonProperty(PropertyName = "charge_account")]
        public string ChargeAccount { get; set; }
        [JsonProperty(PropertyName = "sys_gen")]
        public bool SysGen { get; set; }
        [JsonProperty(PropertyName = "fine_group_origin")]
        public object FineGroupOrigin { get; set; }
        [JsonProperty(PropertyName = "charge_type")]
        public string ChargeType { get; set; }
        [JsonProperty(PropertyName = "settled_amount")]
        public double SettledAmount { get; set; }
        [JsonProperty(PropertyName = "next_fine_process_date")]
        public string NextFineProcessDate { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }
        [JsonProperty(PropertyName = "charge_batch")]
        public object ChargeBatch { get; set; }
        [JsonProperty(PropertyName = "balance")]
        public double Balance { get; set; }
        [JsonProperty(PropertyName = "group_charge_batch_bill_no")]
        public int? GroupChargeBatchBillNo { get; set; }
        [JsonProperty(PropertyName = "credit_account")]
        public string CreditAccount { get; set; }
        [JsonProperty(PropertyName = "__invalid_name__credit_group_origin_id")]
        public int? InvalidNameCreditGroupOriginId { get; set; }

    }
}
