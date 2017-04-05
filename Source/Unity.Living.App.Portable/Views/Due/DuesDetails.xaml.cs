using System;

using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Due
{
    public partial class DuesDetails : ContentPage
    {
        public DuesDetails()
        {
            InitializeComponent();
            btnAccountStatement.Clicked += btnAccountStatement_Clicked;
            btnDuesAccountStatement.Clicked += btnDuesAccountStatement_Clicked;
        }
        private void btnAccountStatement_Clicked(object sender, EventArgs e)
        {
      
        }
        private void btnDuesAccountStatement_Clicked(object sender, EventArgs e)
        {
      
        }
    }
}
