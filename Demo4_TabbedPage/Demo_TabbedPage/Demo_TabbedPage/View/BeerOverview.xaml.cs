using Demo_MasterDetail.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo_TabbedPage.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeerOverview : ContentPage
    {
        public bool? IsAlcoholic { get; set; }

        public BeerOverview()
        {
            InitializeComponent();

            LoadBeerList();
        }

        private void LoadBeerList()
        {
            if (IsAlcoholic == null) lvwBeers.ItemsSource = Beer.GetBeers();
            else lvwBeers.ItemsSource = Beer.GetBeersFiltered((bool)IsAlcoholic);
        }
    }
}