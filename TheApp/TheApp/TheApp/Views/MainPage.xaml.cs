using AppUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TheApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnConexaoTeste(object sender, EventArgs e)
        {
            await App.TransportManager.GetAsync(new PingServer());
            btnSsl.IsEnabled = true;
        }

        async void btnSSLTeste(object sender, EventArgs e)
        {

        }

    }
}
