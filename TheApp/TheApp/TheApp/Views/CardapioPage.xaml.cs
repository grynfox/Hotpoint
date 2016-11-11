using AppUtility.Model;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TheApp.Views
{
    public partial class CardapioPage : ContentPage
    {
        public List<CategoriaDTO> Categorias { get; set; }
        public ObservableCollection<ItensDTO> Itens { get; set; }
        public CategoriaDTO CatSelecionada { get; set; }
        public CardapioPage()
        {
            Itens = new ObservableCollection<ItensDTO>();
            carregaCategorias();
            carregaItens(null);
            BindingContext = this;
            InitializeComponent();
        }

        private async void carregaCategorias()
        {
            IsBusy = true;
            Categorias = await App.TransportManager.GetAsync<List<CategoriaDTO>>(new CategoriaRequest());
            CatPicker.Items.Add("Todas");
            foreach (CategoriaDTO tmp in Categorias)
            {
                CatPicker.Items.Add(tmp.descricao);
            }
            IsBusy = false;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (CatPicker.SelectedIndex == 0)
            {
                carregaItens(null);
            }
            else
            {
                carregaItens(Categorias[CatPicker.SelectedIndex - 1].idCategoria);
            }
        }

        private async void carregaItens(int? idCategoria)
        {
            IsBusy = true;
            var itensTmp = await App.TransportManager.GetAsync<List<ItensDTO>>(new ItensRequest { idCategoria = idCategoria });
            Itens.Clear();
            foreach (var item in itensTmp)
            {
                Itens.Add(item);
            }
            IsBusy = false;
        }
    }
}
