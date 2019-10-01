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
    public partial class ModalNamePage : ContentPage
    {
        public ModalNamePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// this event is called everytime the text changes (characters added or removed)
        /// </summary>
        /// <param name="sender">entry field</param>
        /// <param name="e">extra data on event</param>
        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableDisableControls();
        }

        /// <summary>
        /// enables / disables the go back button based on the input field (valid input?)
        /// </summary>
        private void EnableDisableControls()
        {
            btnNavBack.IsEnabled = IsValidInput();
        }

        /// <summary>
        /// Function that checks whether the input is valid before user can return to previous page
        /// </summary>
        /// <returns>True if entry (input) field contains at least one character that is not a white space</returns>
        private bool IsValidInput()
        {
            return !string.IsNullOrWhiteSpace(txtName.Text);
        }

        private void BtnNavBack_Clicked(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                SaveInputName(); //save input before going back
                //after a pushmodalasync, this page acts as a modal page
                //  therefore, we must do a popMODALasync, otherwise it will crash
                Navigation.PopModalAsync();
            }
        }

        //!! user can still go back on invalid input using the hardware button - we should disable it!

            /// <summary>
            /// Hardware back button was pressed
            /// </summary>
            /// <returns>bool </returns>
        protected override bool OnBackButtonPressed()
        {
            if (!IsValidInput()) //input not valid!
                return true; //cancel back event; stay on page

            SaveInputName(); //save input before going back
            return base.OnBackButtonPressed(); //input is valid => go back as normal
        }


        /// <summary>
        /// saves the user input (< entry field) in the Name property of the main page
        /// </summary>
        private void SaveInputName()
        {
            MainPage.Name = txtName.Text;
        }
    }
}