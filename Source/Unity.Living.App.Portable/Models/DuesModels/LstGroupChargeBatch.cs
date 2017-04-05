using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.DuesModels
{
    public class LstGroupChargeBatch
    {
        [JsonProperty(PropertyName = "due_date")]
        public string DueDate { get; set; }
        [JsonProperty(PropertyName = "invoice_footer_description")]
        public string InvoiceFooterDescription { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "next_fine_process_date")]
        public string NextFineProcessDate { get; set; }
        [JsonProperty(PropertyName = "charge_item")]
        public List<ChargeItem> ChargeItem { get; set; }
        [JsonProperty(PropertyName = "sys_gen")]
        public bool SysGen { get; set; }
        [JsonProperty(PropertyName = "charge_date")]
        public string ChargeDate { get; set; }
        [JsonProperty(PropertyName = "site")]
        public string Site { get; set; }
        [JsonProperty(PropertyName = "charge_setting_id")]
        public int? ChargeSettingId { get; set; }
        [JsonProperty(PropertyName = "fine_setting")]
        public string FineSetting { get; set; }
    }

}
