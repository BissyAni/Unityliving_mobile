using Unity.Living.App.Portable.Interface;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Charge
{
    public partial class ChargeItem : ContentPage
    {
        public ChargeItem(int houseId,int chargeItemId,string houseName)
        {
            InitializeComponent();
            var service = DependencyService.Get<IDuesService>();
            var result =  service.ChargeItemGet(houseId, chargeItemId);
            if (result.Result == null)
            {
                DisplayAlert("No receipt found", "", "OK");
            }
            else
            {
                HouseName.Text = houseName;
                Date.Text = result.Result.charge_item.date;
                Description.Text = result.Result.charge_item.description;
                DueDate.Text = result.Result.charge_item.due_date;
                FineSetting.Text = result.Result.charge_item.fine_setting;
                NextFineProcessDate.Text = result.Result.charge_item.next_fine_process_date;
                AutoSettleFromAdvance.Source = result.Result.charge_item.settle_from_advance ? "ok.png" : "wrong.png";
                IsThisSystemGenerated.Source = result.Result.charge_item.sys_gen ? "ok.png" : "wrong.png";
                Comment.Text = result.Result.charge_item.comment;
            }
        }
    }
}
