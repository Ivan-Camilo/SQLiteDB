using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace SQLiteDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistros : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<Estudiante> TablaEstudiante;
        public ConsultaRegistros()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();
            Obtener();
        }

        public async void Obtener()
        {
            var resultadoEstudiante = await conexion.Table<Estudiante>().ToListAsync();
            TablaEstudiante = new ObservableCollection<Estudiante>(resultadoEstudiante);
            listaEstudiante.ItemsSource = TablaEstudiante;
        }
        
        private void btSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        void listaEstudiante_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Estudiante)e.SelectedItem;
            var itemId = objetoEstudiante.Id.ToString();
            int id = Convert.ToInt32(itemId);
            string nombre = objetoEstudiante.Nombre.ToString();
            string usuario = objetoEstudiante.Usuario.ToString();
            string clave = objetoEstudiante.Clave.ToString();
            Navigation.PushAsync(new Elemento(id, nombre, usuario, clave));
        }
    }
}

