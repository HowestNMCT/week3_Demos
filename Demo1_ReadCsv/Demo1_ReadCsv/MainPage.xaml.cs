using Demo1_ReadCsv.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo1_ReadCsv
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //list of all beers, global variable:
        List<Beer> allBeers;

        public MainPage()
        {
            InitializeComponent();

            //TestModels();
            LoadBeerList();
            ShowBeerList();
        }

        private void LoadBeerList()
        {
            allBeers = Beer.GetBeersFromCsv();
        }

        private void ShowBeerList()
        {
            //1.find list name in xaml
            //2. set list of beers as source
            //  the displayed text in the list is the tostring() result of the beers!
            lvwBeers.ItemsSource = allBeers;
        }

        private void TestModels()
        {
            //use the get beers from csv method:
            List<Beer> beersFromCsv = Beer.GetBeersFromCsv();
        }
    }
}
