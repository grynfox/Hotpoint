using AppUtility.Model;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TheApp.Views.popup
{
    public partial class LogaMesaPopup : ContentPage
    {
        public string senhaMesa { get; set; }
        public MesaDTO mesa { get; private set; }
        public LogaMesaPopup(MesaDTO mesa)
        {
            this.mesa = mesa;
            BindingContext = this;
            InitializeComponent();
        }

        private async void entrar_click(object sender, EventArgs e)
        {
            try
            {
                var result = await App.TransportManager.
                    PostAsync<string>(new MesaAuthentication() { mesaId = mesa.idMesa, senha = senhaMesa });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Falha no login!", ex.Message, "OK");
                return;
            }
            this.Navigation.InsertPageBefore(new CardapioPage(), Navigation.NavigationStack.FirstOrDefault());
            //await Navigation.PopAsync();
            await Navigation.PopToRootAsync();
            App.isLoggedIn = true;
            //string result = App.TransportManager.PostAsync<string>(new MesaAuthentication() { });
        }
    }
}
