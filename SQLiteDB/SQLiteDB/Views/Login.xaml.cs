using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection conexion;

        public Login()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string clave)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante WHERE Usuario =? and Clave =?", usuario, clave);

        }

        void btnInicio_Clicked(System.Object sender, System.EventArgs e)
        {

            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtClave.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistros());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario/Contraseña Incorrectos", "Cerrar");
                }
            }
            catch (Exception)
            {

            }
        }

        void btnRegistro_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }

}

