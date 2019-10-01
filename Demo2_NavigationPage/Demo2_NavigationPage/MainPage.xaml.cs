using Demo2_NavigationPage.Views; //namespace of the pages in my project
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo2_NavigationPage
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// property that stores the name of the current user,
        /// by default this is "anonymous", but this can be changed through the modal page.
        /// </summary>
        public static string Name { get; set; } = "anonymous";


        public MainPage()
        {
            InitializeComponent();

           
        }

        /// <summary>
        /// called everytime the page (re)appears 
        /// </summary>
        protected override void OnAppearing()
        {
            //change the welcome text according to the username:
            //  (this should be called every time the page reopens)
            txtTitle.Text = $"Welcome, {Name}!";

            //basic behavior; leave it here
            base.OnAppearing();
        }

        private void BtnNavModeless_Clicked(object sender, EventArgs e)
        {
            NavigateToNextPage();
        }

        /// <summary>
        /// To be able to navigation from this MainPage, we have to make sure it is a NavigationPage!! (App.xaml.cs)
        /// </summary>
        private void NavigateToNextPage()
        {
            //pass the name of the user to the modeless page!
            Navigation.PushAsync(new ModelessPage( Name ));
        }

        private void BtnNavModal_Clicked(object sender, EventArgs e)
        {
            //the only thing that converts the ModalNamePage to a modal page, is the fact
            //  that we push MODAL async. Should we pushasync instead, the page would be a modeless page.
            Navigation.PushModalAsync(new ModalNamePage());
        }
    }
}
