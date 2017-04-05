using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public class Posted
    {
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "address1")]
        public string Address1 { get; set; }
        [JsonProperty(PropertyName = "surl")]
        public string Surl { get; set; }
        [JsonProperty(PropertyName = "txnid")]
        public string TransanctionId { get; set; }
        [JsonProperty(PropertyName = "productinfo")]
        public string ProductInfo { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        [JsonProperty(PropertyName = "furl")]
        public string Furl { get; set; }
    }

    public class OnlinePaymentModel
    {
        [JsonProperty(PropertyName = "hash")]
        public string Hash { get; set; }
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        [JsonProperty(PropertyName = "err")]
        public string Error { get; set; }
        [JsonProperty(PropertyName = "payment_url")]
        public string PaymentUrl { get; set; }
        [JsonProperty(PropertyName = "prepaymentid")]
        public int PrepaymentId { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "hash_string")]
        public string HashString { get; set; }
        [JsonProperty(PropertyName = "txnid")]
        public string TransactionId { get; set; }
        [JsonProperty(PropertyName = "posted")]
        public Posted Posted { get; set; }
    }
}
