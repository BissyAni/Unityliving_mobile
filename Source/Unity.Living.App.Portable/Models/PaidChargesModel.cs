using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public   class PaidChargesModel
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "mode_of_payment")]
        public string ModeOfPayment { get; set; }
        [JsonProperty(PropertyName = "bank_name")]
        public string BankName { get; set; }
        [JsonProperty(PropertyName = "bank_branch")]
        public string BankBranch { get; set; }
        [JsonProperty(PropertyName = "cheque_no")]
        public string ChequeNumber { get; set; }
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "paid_charges_id")]
        public string PaidChargesId { get; set; }        
    }
}
