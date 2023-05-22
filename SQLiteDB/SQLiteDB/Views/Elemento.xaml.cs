using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SQLiteDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        private int idSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<Estudiante> REactualizar;
        IEnumerable<Estudiante> REeliminar;
        public Elemento(int id, string nombre, string usuario, string clave)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            txtClave.Text = clave;
            conexion = DependencyService.Get<DataBase>().GetConnection();
            idSeleccionado = id;
        }

        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante Where Id =?", id);
        }

        public static IEnumerable<Estudiante> Actualizar(SQLiteConnection db, string nombre, string usuario, string clave, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante set Nombre =?, Usuario =?, clave =? Where Id =?", nombre, usuario, clave, id);
        }

        private async void btActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                if (await DisplayAlert("Confirmación", "¿Está seguro que desea actualizar el elemento", "SI", "NO"))
                {
                    REactualizar = Actualizar(db, txtNombre.Text, txtUsuario.Text, txtClave.Text, idSeleccionado);
                    await Navigation.PushAsync(new ConsultaRegistros());
                }
                else
                {
                    await DisplayAlert("Mensaje", "No se pudo actualizar al estudiante", "Aceptar");
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "Cerrar");
            }

        }

        private async void btEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                if (await DisplayAlert("Confirmación", "¿Está seguro que desea eliminar el elemento?", "SI", "NO"))
                {
                    REeliminar = Eliminar(db, idSeleccionado);
                    await Navigation.PushAsync(new ConsultaRegistros());
                }
                else
                {
                    await DisplayAlert("Mensaje", "No se pudo eliminar al estudiante", "Aceptar");
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }
    }
}

