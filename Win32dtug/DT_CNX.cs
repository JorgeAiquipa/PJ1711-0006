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
        public string conexion;
        public DT_CNX()
        {
            conexion = ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString();
        }
    }
}
