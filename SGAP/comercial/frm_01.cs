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

namespace SGAP.comercial
{
    public partial class frm_01 : Form
    {
        #region Instancias


        ET_entidad _entidad = new ET_entidad();
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

            //Resta 1 mes al filtro de la fecha de inicio
            dtp_fecha_inicio.Value = dtp_fecha_fin.Value.AddMonths(-1);

            //style
            pnl_filter_wraper.BackColor = Color.FromArgb(65,48,124);
            pnl_cd_close.BackColor = Color.FromArgb(55,41,106);

            cargar_cotizaciones();
            filter_cotizaciones();

            //Columnas
            listView_Cotizaciones.Columns.Add("Codigo cotización",210);
            listView_Cotizaciones.Columns.Add("Id cliente",0);

            listView_Cotizaciones.Columns.Add("Cliente",210);
            listView_Cotizaciones.Columns.Add("Ruc",160);
            listView_Cotizaciones.Columns.Add("Cantidad locales",100);
            listView_Cotizaciones.Columns.Add("Creado por",200);
            listView_Cotizaciones.Columns.Add("Fecha creación",200);
            //listView_Cotizaciones.Columns.Add("Fecha actualización",200);
            //propiedades
            listView_Cotizaciones.View = View.Details;
            listView_Cotizaciones.FullRowSelect = true;

            listView_Cotizaciones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);


            splitContainer1.SplitterDistance = 180;


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
            frm_01_1 frm_01_1 = new frm_01_1();
            frm_01_1.ShowDialog();

            try
            {

                frm_01_2 F2 = new frm_01_2(frm_01_1._entity);
                cargar_cotizaciones();
                F2.ShowDialog();
            }
            catch (Exception ex)
            {
                //
            }
        }

        public void cargar_cotizaciones()
        {
            _nt_m39.get_001(listView_Cotizaciones);
            cantidad();
            //filter_cotizaciones();
        }
        void filter_cotizaciones()
        {

            DateTime fecha_inicio = new DateTime(dtp_fecha_inicio.Value.Year, dtp_fecha_inicio.Value.Month, dtp_fecha_inicio.Value.Day);
            DateTime fecha_fin = new DateTime(dtp_fecha_fin.Value.Year, dtp_fecha_fin.Value.Month, dtp_fecha_fin.Value.Day,hour:23,minute:59,second:29);

            _nt_m39._et_m39._filtro = txt_cliente_or_ruc.Text;
            _nt_m39._et_m39._fecha_Inicio = fecha_inicio;
            _nt_m39._et_m39._fecha_Fin = fecha_fin;
            _nt_m39.get_002(listView_Cotizaciones);

            cantidad();
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
            string codigo_cliente = listView_Cotizaciones.SelectedItems[0].SubItems[1].Text;
            string descripcion_cliente = listView_Cotizaciones.SelectedItems[0].SubItems[2].Text;

            _entidad = new ET_entidad();
            _entidad._entity_m39._TM39_ID = codigo_cotizacion;
            _entidad._entity_m39._entity_et_m19._TM19_ID = codigo_cliente;
            _entidad._entity_m39._entity_et_m19._TM19_DESCRIP2 = descripcion_cliente; //razon social

            frm_01_2 F2 = new frm_01_2(_entidad, true);
            cargar_cotizaciones();
            filter_cotizaciones();
            F2.ShowDialog();
        }

        //Quitar filtro
        private void button1_Click(object sender, EventArgs e)
        {
            txt_cliente_or_ruc.Text = "";
            dtp_fecha_fin.Text =Convert.ToString(DateTime.Today);

            //Resta 1 mes al filtro de la fecha de inicio
            dtp_fecha_inicio.Value = dtp_fecha_fin.Value.AddMonths(-1);

            txt_cliente_or_ruc.Focus();

            cargar_cotizaciones();
            filter_cotizaciones();
        }


        private void cantidad()
        {
            string cant = Convert.ToString(listView_Cotizaciones.Items.Count);
            if(Convert.ToInt32(cant) == 1)
            {
                toolStripStatusLabel1.Text = cant + " cotización encontrada";
            }else
            {
                toolStripStatusLabel1.Text = cant + " cotizaciones encontradas";
            }
        }




        #endregion

        private void pnl_cd_close_Click(object sender, EventArgs e)
        {
            //if(splitContainer1.SplitterDistance > 25)
            //{
            //    splitContainer1.SplitterDistance = 24;
            //}
            //else
            //{
            //    splitContainer1.SplitterDistance = 257;
            //}
        }

        private void txt_cliente_or_ruc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filter_cotizaciones();
            }
        }
    }

}
