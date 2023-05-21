using System;
using SQLite;

namespace SQLiteDB
{
	public class Estudiante
	{
		[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
		[MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Usuario { get; set; }

        [MaxLength(50)]
        public string Clave { get; set; }

    }
}

