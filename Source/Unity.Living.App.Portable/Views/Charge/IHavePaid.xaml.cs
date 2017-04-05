using Unity.Living.App.Portable.Models.DuesModels;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Charge
{
    public partial class IHavePaid : BaseContentPage
    {
        private readonly DueSummaryViewModel viewModel;
        public IHavePaid(int hId)
        {
            BindingContext = viewModel = new DueSummaryViewModel(hId, Navigation);
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            if (!viewModel.Initialized)
                await viewModel.Initialize();

            if (viewModel.GetGroupChargeList.Count > 0)
                GroupCharges.HeightRequest = (viewModel.GetGroupChargeList.Count * 68.5);
            else
                GroupChargesGrid.IsVisible = false;

            if (viewModel.GetChargeList.Count > 0)
                ReadingView.HeightRequest = (viewModel.GetChargeList.Count * 68.5);
            else
                ChargesGrid.IsVisible = false;
            base.OnAppearing();
        }

        private void GroupCharge_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var tappedItem = (WrappedListItems<Models.DuesModels.ChargeItem>)e.SelectedItem;
            tappedItem.IsChecked = !tappedItem.IsChecked;
            tappedItem.UnChecked = !tappedItem.UnChecked;
            ((ListView)sender).SelectedItem = null;
            viewModel.TotalAmountSelected(tappedItem);
        }
        private void Charge_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var tappedItem = (WrappedListItems<DuesList>)e.SelectedItem;
            tappedItem.IsChecked = !tappedItem.IsChecked;
            tappedItem.UnChecked = !tappedItem.UnChecked;
            ((ListView)sender).SelectedItem = null;
            viewModel.TotalAmountSelected(tappedItem);
        }
    }
}
