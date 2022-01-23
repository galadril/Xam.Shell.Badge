using System;
using Xamarin.Forms;

namespace Xam.Shell.Badge.Sample
{
    public partial class MainPage
    {
        public MainPage() =>
            InitializeComponent();

        private void btnRemove_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "RemoveBadge");
        }

        private void btnColor_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "ChangeColorBadge");
        }

        private void btnText_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "ChangeTextBadge");
        }

        private void btnZeroText_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "ChangeTextToZero");
        }
    }
}