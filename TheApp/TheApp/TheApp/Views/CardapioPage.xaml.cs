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
        public ObservableCollection<CategoriaDTO> teste { get; set; }
        public CategoriaDTO CatSelecionada { get; set; }
        public CardapioPage()
        {
            teste = new ObservableCollection<CategoriaDTO>();
            teste.Add(new CategoriaDTO() { descricao = "blalbalbla", idCategoria = -1 });
            carregaCategorias();
            BindingContext = this;
            InitializeComponent();
        }

        private async void carregaCategorias()
        {
            Categorias = await App.TransportManager.GetAsync<List<CategoriaDTO>>(new CategoriaRequest());
            CatPicker.Items.Add("Todas");
            foreach (CategoriaDTO tmp in Categorias)
            {
                CatPicker.Items.Add(tmp.descricao);
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CatPicker.SelectedIndex > 0)
                CatSelecionada = Categorias[CatPicker.SelectedIndex - 1];

            teste.Add(CatSelecionada);
        }
    }
}
