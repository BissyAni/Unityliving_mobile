using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public class ChargeItemModel
    {
        [JsonProperty(PropertyName = "charge_item")]
        public ChargeItemInvoice ChargeItem { get; set; }
    }
}
