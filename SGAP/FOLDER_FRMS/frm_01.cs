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

namespace SGAP.FOLDER_FRMS
{
    public partial class frm_01 : Form
    {
        #region Instancias


        ET_entidad et = new ET_entidad();
        ET_M39 _et_m39 = new ET_M39();

        NT_M39 _nt_m39 = new NT_M39();
        ET_globales _globales = new ET_globales();
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

            cargar_cotizaciones();

            //Columnas
            listView_Cotizaciones.Columns.Add("Codigo Cotización",210);
            listView_Cotizaciones.Columns.Add("Cliente",210);
            listView_Cotizaciones.Columns.Add("Ruc",160);
            listView_Cotizaciones.Columns.Add("Cantidad Locales",100);
            listView_Cotizaciones.Columns.Add("Creado Por",200);
            listView_Cotizaciones.Columns.Add("Fecha Creación",200);
            listView_Cotizaciones.Columns.Add("Fecha actualización",200);
            //propiedades
            listView_Cotizaciones.View = View.Details;
            listView_Cotizaciones.FullRowSelect = true;

        }

        #region Métodos
        void Poblar_LV(string cliente, string ruc, int cant_loc, string creado_por, DateTime fecha_Cre,DateTime fecha_actu)
        {
            string[] row = { cliente, ruc, cant_loc.ToString(), creado_por, fecha_Cre.ToString(), fecha_actu.ToString() };
            listView_Cotizaciones.Items.Add(new ListViewItem(row));
        }
        void call_Form()
        {
            // Llamanos al formulario de informcaion general
            FORLDER_FRMS.frm_01_1 frm_01_1 = new FORLDER_FRMS.frm_01_1();
            frm_01_1.ShowDialog();

            try
            {

                FORLDER_FRMS.frm_01_2 F2 = new FORLDER_FRMS.frm_01_2(frm_01_1._entity);
                cargar_cotizaciones();
                F2.ShowDialog();
            }
            catch (Exception ex)
            { }
        }

        public void cargar_cotizaciones()
        {
            _nt_m39.get_001(listView_Cotizaciones);
        }
        void filter_cotizaciones()
        {

            DateTime fecha_inicio = new DateTime(dtp_fecha_inicio.Value.Year, dtp_fecha_inicio.Value.Month, dtp_fecha_inicio.Value.Day);
            DateTime fecha_fin = new DateTime(dtp_fecha_fin.Value.Year, dtp_fecha_fin.Value.Month, dtp_fecha_fin.Value.Day,hour:23,minute:59,second:29);

            _nt_m39._et_m39._filtro = txt_cliente_or_ruc.Text;
            _nt_m39._et_m39._fecha_Inicio = fecha_inicio;
            _nt_m39._et_m39._fecha_Fin = fecha_fin;
            _nt_m39.get_002(listView_Cotizaciones);
        }

        #endregion

        #region Eventos
        private void btnNuevoCotizacion_Click(object sender, EventArgs e)
        {
            call_Form();
        }

        private void txt_cliente_or_ruc_TextChanged(object sender, EventArgs e)
        {
            cliente_or_ruc = txt_cliente_or_ruc.Text;
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {
            filter_cotizaciones();
        }

        private void listView_Cotizaciones_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string codigo_cotizacion = listView_Cotizaciones.SelectedItems[0].SubItems[0].Text;

            //abrir cotizacion para editar en funcion al codigo de la cotizacion


        }
    }
        #endregion


}
