using Android.Views;
using System;
using Unity.Living.App.Portable.Models.DuesModels;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Due
{
    public partial class DuesViewDetails : BaseContentPage
    {
        private readonly DueSummaryViewModel viewModel;
        Color even = Color.Silver;
        Color odd = Color.White;
        Color tapped = Color.Blue;
        ListViewAlternatingRowProcessor _listViewProcessor = new ListViewAlternatingRowProcessor(Color.FromHex("#e3f2fd"), Color.White, Color.Blue);

        public DuesViewDetails(int hId)
        {
            BindingContext = viewModel = new DueSummaryViewModel(hId, Navigation);
            InitializeComponent();
        }

        private void Cell_OnAppearing(object sender, EventArgs e)
        {
            _listViewProcessor.SetBackColor(sender);
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
            var tappedItem = (WrappedListItems<ChargeItem>)e.SelectedItem;
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
    public class ListViewAlternatingRowProcessor
    {
        private bool _isEvenRow;
        private Color _evenRowColor;
        private Color _oddRowColor;
        private Color _tappedColor;

        private ViewCell _previouslyTappedCell = null;
        private Color? _previouslyTappedCellNaturalBackColor;

        public ListViewAlternatingRowProcessor(Color evenBackColor, Color oddBackColor, Color tappedColor)
        {
            _evenRowColor = evenBackColor;
            _oddRowColor = oddBackColor;
            _tappedColor = tappedColor;
        }

        public void SetBackColor(object viewCellSender)
        {
            var viewCell = (ViewCell)viewCellSender;

            Color bg = _oddRowColor;

            //viewCell.Tapped += ViewCell_Tapped;

            if (_isEvenRow)
            {
                bg = _evenRowColor;
            }

            _isEvenRow = !_isEvenRow;

            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = bg;

            }
        }

        //private void ViewCell_Tapped(object sender, EventArgs e)
        //{
        //    var viewCell = (ViewCell)sender;

        //    if (_previouslyTappedCellNaturalBackColor.HasValue)
        //    {
        //        _previouslyTappedCell.View.BackgroundColor = _previouslyTappedCellNaturalBackColor.Value;
        //    }

        //    if (viewCell.View != null)
        //    {
        //        _previouslyTappedCellNaturalBackColor = viewCell.View.BackgroundColor;
        //        viewCell.View.BackgroundColor = _tappedColor;

        //        _previouslyTappedCell = viewCell;
        //    }
        //}
    }
}
