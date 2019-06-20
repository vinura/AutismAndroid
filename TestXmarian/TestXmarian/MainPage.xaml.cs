using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXmarian.Services;
using Xamarin.Forms;
using TestXmarian;

namespace TestXmarian
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Padding = new Thickness(20,20,20,20);
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);  // Hide nav bar

            //   BindingContext = this;


        }



        private async void Post_Clicked(object sender, EventArgs e)
        {

            var sexf = "";
            if (sex.SelectedItem.ToString() == "Female")
            {
                sexf = "f";
            }
            else
            {
                sexf = "m";
            }



            AutismProfile temoUser = new AutismProfile()
            {
                A1 = a1.SelectedIndex,
                A2 = a2.SelectedIndex,
                A3 = a3.SelectedIndex,
                A4 = a4.SelectedIndex,
                A5 = a5.SelectedIndex,
                A6 = a6.SelectedIndex,
                A7 = a7.SelectedIndex,
                A8 = a8.SelectedIndex,
                A9 = a9.SelectedIndex,
                A10 = a10.SelectedIndex,
                Age = float.Parse(age.Text),
                Sex = sexf,
                Jaundice = jaundice.SelectedItem.ToString().ToLower(),
                Ethnicity = ethnicity.SelectedItem.ToString(),
                Family_ASD = asd.SelectedItem.ToString(),
                Language = language.SelectedItem.ToString().ToLower(),
                User = user.SelectedItem.ToString().ToLower(),
                Class = ""

            };

            var data = new ProfileData(temoUser);

            var model = new Services.PredictService().PredAutism(data);

            var xmodel = model.Result;

            var label = xmodel.Label;
            var prob = xmodel.Probability.ToString();

            var labelx= "";

            if (label == "YES")
            {
                labelx = "You have Autism";
            }
            else
            {
                labelx = "You don't have Autism";
            }

            await Navigation.PushModalAsync(new ResultsAutism(labelx, prob));

        }

    }
}

