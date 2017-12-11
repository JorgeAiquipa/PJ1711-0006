/**
 * Description: daoConexion.
 * Version: 1.0.0
 * Last update: 2017/12/02
 * Author: User Name <cesar.freitas@actecperu.com>
 *
   ========================================================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Win32dtug
{
    public class DT_CNX
    {
        public static DT_MAIN _DT_MAIN; 
        public static bool Abrir_conexion()
        {
            string nombreServidor = @"PORTATIL-PC\SQLEXPRESS";
            string baseDatos = "bd_Desarrollo";
            string usuario = "sa";
            string password = "cesar.freitas";

            _DT_MAIN = new DT_MSSQL(nombreServidor, baseDatos, usuario, password);
            try
            {
                return _DT_MAIN.Autenticar();
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static void Cerrar_conexion()
        {
            _DT_MAIN.CerrarConexion();
        } 

    }
}
