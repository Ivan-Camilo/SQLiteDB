using System;
using SQLite;
namespace SQLiteDB
{
	public interface DataBase
	{
		SQLiteAsyncConnection GetConnection(); //definir el metodo de conexion
	}


}

