using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.DueStatement
{
    public class AccountData
    {
        [JsonProperty(PropertyName = "value_date")]
        public string ValueDate { get; set; }
        [JsonProperty(PropertyName = "document_num")]
        public object DocumentNumber { get; set; }
        [JsonProperty(PropertyName = "credit_amount")]
        public double CreditAmount { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "debit_amount")]
        public double DebitAmount { get; set; }
        [JsonProperty(PropertyName = "document")]
        public string Document { get; set; }
        [JsonProperty(PropertyName = "dues_balance")]
        public double DuesBalance { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}
