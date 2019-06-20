using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXmarian
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsAutism : ContentPage
    {
        public ResultsAutism(string res, string proba)
        {
            InitializeComponent();
            Padding = new Thickness(30, 30, 30, 30);
            reslt.Text = res;
            prob.Text = proba;
        }
    }
}