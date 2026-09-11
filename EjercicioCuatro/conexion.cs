using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EjercicioCuatro
{
    class conexion
    {
        public string servidor, usuario, clave, db;
        public string cadena;

        public void conec()
        {
            servidor = "3375898HP"; // Cambiar por el nombre del servidor
            db = "db_tarea";
            usuario = "sa";
            clave = "123456";
            cadena = "server=" + servidor + ";uid=" + usuario + ";pwd=" + clave + ";database=" + db;
        }
    }
}
