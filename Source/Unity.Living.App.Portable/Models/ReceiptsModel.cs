﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Unity.Living.App.Portable.Models
{
    public class Receipts
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "created_date")]
        public string CreatedDate { get; set; }
        [JsonProperty(PropertyName = "updated_date")]
        public string UpdatedDate { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "advance")]
        public bool Advance { get; set; }
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }
        [JsonProperty(PropertyName = "eft")]
        public bool EFT { get; set; }
        [JsonProperty(PropertyName = "cheque_no")]
        public object ChequeNumber { get; set; }
        [JsonProperty(PropertyName = "bank_name")]
        public object BankName { get; set; }
        [JsonProperty(PropertyName = "bank_branch")]
        public object BankBranch { get; set; }
        [JsonProperty(PropertyName = "number")]
        public object Number { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }
        [JsonProperty(PropertyName = "excess_amount")]
        public string ExcessAmount { get; set; }
        [JsonProperty(PropertyName = "advance_balance")]
        public string AdvanceBalance { get; set; }
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
        [JsonProperty(PropertyName = "dues_balance")]
        public string DuesBalance { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "online_txn_id")]
        public object OnlineTransanctionId { get; set; }
        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get; set; }
        [JsonProperty(PropertyName = "sys_gen")]
        public bool SysGen { get; set; }
        [JsonProperty(PropertyName = "created_user")]
        public int CreatedUser { get; set; }
        [JsonProperty(PropertyName = "updated_user")]
        public object UpdatedUser { get; set; }
        [JsonProperty(PropertyName = "house")]
        public int House { get; set; }
        [JsonProperty(PropertyName = "source_account")]
        public int SourceAccount { get; set; }
        [JsonProperty(PropertyName = "site")]
        public int Site { get; set; }
    }

    public class ReceiptsModel
    {
        [JsonProperty(PropertyName = "receipts")]
        public List<Receipts> Receipts { get; set; }
    }
    
}
