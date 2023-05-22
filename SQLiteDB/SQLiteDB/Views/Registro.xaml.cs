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
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public Registro()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistrar_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var datos = new Estudiante
                {
                    Nombre = txtNombre.Text,
                    Usuario = txtUsuario.Text,
                    Clave = txtClave.Text
                };

                conexion.InsertAsync(datos); //Ingreso de datos a la base


                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtClave.Text = "";
            }

            catch (Exception ex)
            {

            }
        }

        void btnRegresar_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}

