using System;
using Xamarin.Forms;
using Unity.Living.AppAndroid;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Models.DuesModels;

[assembly: Dependency(typeof(DuesServiceAndroid))]

namespace Unity.Living.AppAndroid.Service
{
}

public class DuesServiceAndroid : ServiceBaseAndroid, IDueService
{
    public async Task<DuesModel> GetDues(int houseId)
    {
        var url = string.Format(UrlHelper.HouseDues, houseId);
        var json = await FetchAsync(url);
        var result = JsonConvert.DeserializeObject<DuesModel>(json);
        return result;
    }

    public async Task<ReceiptsModel> GetDuereceipts(int houseId)
    {
        var url = string.Format(UrlHelper.DuesReceiptList, houseId);
        var json = await FetchAsync(url);
        var result = JsonConvert.DeserializeObject<ReceiptsModel>(json);
        return result;
    }

    public async Task<OnlinePaymentModel> PayAdvance(PayAdvanceModel payAdvModel, int houseId)
    {
        var json = await PostAsyncCustom<PayAdvanceModel>(UrlHelper.PayAdvanceOnlinePayment + houseId, payAdvModel);
        var result = JsonConvert.DeserializeObject<OnlinePaymentModel>(json);
        return result;
    }

    public async Task<OnlinePaymentModel> SettleDuePostForPayment(SettleDuesPostModel setlDuePostModel, int houseId)
    {

        var json = await PostAsyncCustom<SettleDuesPostModel>(UrlHelper.DuesOnlineSettle + houseId, setlDuePostModel);
        var result = JsonConvert.DeserializeObject<OnlinePaymentModel>(json);
        return result;

    }

    public async Task<bool> PaidChargesPost(PaidChargesModel PaidModel)
    {
        var json = await PostAsyncCustom<PaidChargesModel>(UrlHelper.PaiditemCreate, PaidModel);
        if (json == "{\"success\":true}")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<ChargeItemModel> ChargeItemGet(int houseId, int chargeItemId)
    {

        var url = string.Format(UrlHelper.ChargeItemView, houseId, chargeItemId);
        var json = await FetchAsync(url);
        if (json == "\"Invalid Request\"")
        {
            return null;
        }
        else
        {
            var result = JsonConvert.DeserializeObject<ChargeItemModel>(json);
            return result;
        }
    }

    public async Task<ReceiptViewModel> GetReceiptView(int Id)
    {
        var url = string.Format(UrlHelper.DuesReceiptView, Id);
        var json = await FetchAsync(url);
        var result = JsonConvert.DeserializeObject<ReceiptViewModel>(json);
        return result;
    }

    public async Task<SettleDuesModel> GetSettleDues(int houseId, PayOnlineModel payOnlineModel)
    {
        var json = await PostAsyncCustom<PayOnlineModel>(UrlHelper.DuesSettle + houseId, payOnlineModel);
        var result = JsonConvert.DeserializeObject<SettleDuesModel>(json);
        return result;
    }

    public async Task<string> PaymentURL(OnlinePaymentModel paymentModel)
    { 
        var client = new RestClient(UrlHelper.PayuPayment);
        var request = new RestRequest(Method.POST);
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("content-type", "application/x-www-form-urlencoded");
        string parrameterValue = "key=" + paymentModel.Key + "&txnid=" + paymentModel.TransactionId + "&amount=" + paymentModel.Posted.Amount + "&productinfo=" + paymentModel.Posted.ProductInfo + "&firstname=" + paymentModel.Posted.FirstName + "&email=" + paymentModel.Posted.Email + "&phone=" + paymentModel.Posted.Phone + "&surl=" + paymentModel.Posted.Surl + "&furl=" + paymentModel.Posted.Furl + "&hash=" + paymentModel.Hash + "&address1=" + paymentModel.Posted.Address1;
        request.AddParameter("application/x-www-form-urlencoded", parrameterValue, ParameterType.RequestBody);        
        IRestResponse response = client.Execute(request);
        string mihPayIdValue = response.ResponseUri.AbsoluteUri;
        if (mihPayIdValue != null)
            return mihPayIdValue;
        else
            return null;

    }
}

