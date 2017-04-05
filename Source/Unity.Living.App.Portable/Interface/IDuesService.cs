using System.Threading.Tasks;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Models.DuesModels;

namespace Unity.Living.App.Portable.Interface
{
    public interface IDueService
    {
        Task<DuesModel> GetDues(int houseId);
        Task<ReceiptsModel> GetDuereceipts(int houseId);
        Task<OnlinePaymentModel> PayAdvance(PayAdvanceModel payAdvModel,int houseId);
        Task<bool> PaidChargesPost(PaidChargesModel paid);
        Task<ChargeItemModel> ChargeItemGet(int houseId, int chargeItemId);
        Task<string> PaymentURL(OnlinePaymentModel paymentModel);
        Task<SettleDuesModel> GetSettleDues(int houseId,PayOnlineModel payOnlineModel);
        Task<OnlinePaymentModel> SettleDuePostForPayment(SettleDuesPostModel setlDuePostModel,int houseId);
        Task<ReceiptViewModel> GetReceiptView(int Id);   
    }
}
