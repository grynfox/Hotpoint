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
            try
            {
                var result = await App.TransportManager.GetAsync(new PingServer());
                await DisplayAlert("Sucesso", result, "Ok");
                btnSsl.IsEnabled = true;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }

        }

        async void btnSSLTeste(object sender, EventArgs e)
        {

        }

    }
}
