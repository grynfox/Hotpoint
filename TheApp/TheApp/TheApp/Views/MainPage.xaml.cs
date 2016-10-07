﻿using AppUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TheApp.Views
{

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<MesaDTO> Mesas { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Mesas = new ObservableCollection<MesaDTO>();
            this.BindingContext = this;
        }

        async void btnConexaoTeste(object sender, EventArgs e)
        {
            try
            {
                var result = await App.TransportManager.GetAsync<List<MesaDTO>>(new MesaRequest());
                foreach(var mesa in result)
                {
                    Mesas.Add(mesa);
                }
                //await DisplayAlert("Sucesso", result[0]?.nomeMesa, "Ok");
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
