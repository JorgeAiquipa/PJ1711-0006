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
       // public string _cnx = @"data source=TCP:192.168.1.5\DESA001,1434;initial catalog=DBPisersa;user id=sa;password=123456;persist security info=True;user id=sa;packet size=4096";
        public static DT_MAIN _DT_MAIN;

        public static bool Abrir_conexion()
        {
            string nombreServidor = @"TCP:192.168.1.5\DESA001,1434";//@"PORTATIL-PC\SQLEXPRESS";
            string baseDatos = "DBPisersa";
            string usuario = "sa";
            string password = "123456";

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
