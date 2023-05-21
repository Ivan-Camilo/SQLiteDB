using System;
using SQLite;
using System.IO;
using SQLiteDB.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ClienteAndroid))]
namespace SQLiteDB.Droid
{
    public class ClienteAndroid : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var BaseDatos = Path.Combine(ruta, "uisrael.db3");
            return new SQLiteAsyncConnection(BaseDatos);
        }
    }
}


