using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo2_NavigationPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModelessPage : ContentPage
    {
        //force the user to pass the name through the parameter
        public ModelessPage(string username)
        {
            InitializeComponent();

            //change title with username
            txtTitle.Text = $"{username}'s modeless page.";
        }

        private void BtnNavBack_Clicked(object sender, EventArgs e)
        {
            GoBack();
        }

        private void GoBack()
        {
            //no input control needed; user can go back anytime he wants (modeless page)
            Navigation.PopAsync();
        }
    }
}