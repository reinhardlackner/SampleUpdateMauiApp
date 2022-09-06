using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleUpdateApp
{
    public partial class MainPage : ContentPage
    {
        private string counterFilePath = FileSystem.AppDataDirectory + @"\info.txt";

        public MainPage()
        {
            InitializeComponent();

            RefreshCounterInfo();
            btnCounter.Clicked += BtnCounter_Clicked;

            lblStoragePath.Text = "Counter storage path: " + counterFilePath;
        }

        private void BtnCounter_Clicked(object sender, EventArgs e)
        {
            IncreaseAndSaveCounterInfo();
            RefreshCounterInfo();
        }

        private void IncreaseAndSaveCounterInfo()
        {
            //Write counter info to Textfile
            int nrOfClicks = 0;
            if (System.IO.File.Exists(counterFilePath))
                nrOfClicks = Convert.ToInt32(System.IO.File.ReadAllText(counterFilePath));
            nrOfClicks++;
            System.IO.File.WriteAllText(counterFilePath, nrOfClicks.ToString());
        }

        private void RefreshCounterInfo()
        {
            int nrOfClicks = 0;
            if (System.IO.File.Exists(counterFilePath))
                nrOfClicks = Convert.ToInt32(System.IO.File.ReadAllText(counterFilePath));

            lblClickInfo.Text = $"Nr of clicks: {nrOfClicks}";

        }

    }
}
