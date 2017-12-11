using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Win28etug;
using Win28ntug;

namespace SGAP
{
    public partial class frm_01 : Form
    {
        #region Instancias

        ET_entidad et = new ET_entidad();
        #endregion
        #region Variables
        string cliente_or_ruc;
        string fecha_inicio;
        string fecha_fin;

        #endregion
        public frm_01()
        {
            InitializeComponent();

            //style
            pnl_filter_wraper.BackColor = Color.FromArgb(65,48,124);
            pnl_cd_close.BackColor = Color.FromArgb(55,41,106);


            dgv_cotizaciones.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);
            dgv_cotizaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);
            dgv_cotizaciones.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood;
            dgv_cotizaciones.EnableHeadersVisualStyles = false;
            dgv_cotizaciones.RowHeadersVisible = true;

            dgv_cotizaciones.BackgroundColor = Color.Silver;

            cargar_cotizaciones();
        }

        #region Métodos
        void call_Form()
        {
            // Llamanos al formulario de informcaion general
            FORLDER_FRMS.frm_01_1 frm_01_1 = new FORLDER_FRMS.frm_01_1();
            frm_01_1.Show();
        }

        void cargar_cotizaciones()
        {

        }
        void filtrar_entre_fechas()
        {

        }

        void filtrar_por_estado()
        {

        }
        #endregion

        #region Eventos
        private void btnNuevoCotizacion_Click(object sender, EventArgs e)
        {
            call_Form();
        }
        private void btn_betweenDates_Click(object sender, EventArgs e)
        {
            fecha_inicio = dtp_fecha_inicio.Value.ToShortDateString(); // return "11/12/2017"
            fecha_fin = dtp_fecha_fin.Value.ToShortDateString();

            // llamar a  metodo
            filtrar_entre_fechas();

        }

        private void chkb_estado_aprobado_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_por_estado();
        }

        private void chkb_estado_cerrado_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_por_estado();

        }

        private void chkb_estado_pendiente_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_por_estado();

        }

        private void txt_cliente_or_ruc_TextChanged(object sender, EventArgs e)
        {
            cliente_or_ruc = txt_cliente_or_ruc.Text;
        }
    }
        #endregion


}
