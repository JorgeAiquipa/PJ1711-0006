using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Win28etug;
using Win28ntug;

namespace SGAP.comercial
{
    public partial class frm_01 : Form
    {

        #region Instancias
        ET_globales Globales = new ET_globales();
        ET_entidad Entidad_ = new ET_entidad();
        NT_tareas Tarea = new NT_tareas();
        ET_M39 _et_m39 = new ET_M39();
        NT_M39 _nt_m39 = new NT_M39();
        Label lbl_info_list = new Label();
        #endregion

        #region Variables
        string cliente_or_ruc;
        ImageList icon = new ImageList();
        #endregion

        #region Métodos

        //[DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        //private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);
        //[DllImport("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        //public int MakeLong(short lowPart, short highPart)
        //{
        //    return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        //}

        //public void ListViewItem_SetSpacing(ListView listview, short leftPadding, short topPadding)
        //{
        //    const int LVM_FIRST = 0x1000;
        //    const int LVM_SETICONSPACING = LVM_FIRST + 53;
        //    SendMessage(listview.Handle, LVM_SETICONSPACING, IntPtr.Zero, (IntPtr)MakeLong(leftPadding, topPadding));
        //}
        public frm_01()
        {
            InitializeComponent();
            //SetWindowTheme(listView_Cotizaciones.Handle, "Explorer", null);
            //ListViewItem_SetSpacing(listView_Cotizaciones, 64 + 32, 100 + 16);
            dtp_fecha_inicio.Value = dtp_fecha_fin.Value.AddMonths(-1);
            dtp_fecha_inicio.MaxDate = DateTime.Now;
            dtp_fecha_fin.MaxDate = DateTime.Now;
            //style
            pnl_filter_wraper.BackColor = Color.FromArgb(0, 137, 123);//(65,48,124);
            //pnl_cd_close.BackColor = Color.FromArgb(55,41,106);
            panel2.BackColor = Color.FromArgb(0, 137, 123);
            panel_first_detail.Controls.Add(lbl_info_list);
            lbl_info_list.Location = new Point(10, 7);
            btn_limpiar_filtro.Enabled = false;
            Crear_ListView();

            _nt_m39.Cargar_explorador_De_cotizaciones_ += Cargar_explorador_De_cotizaciones;
            _nt_m39.Porcentaje_de_Carga += Porcentaje_De_carga;
            _nt_m39.Mensaje_Info += Mensaje_Info;
            Obtener_Cotizaciones();

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        void Crear_ListView()
        {
            icon.TransparentColor = Color.White;
            icon.ColorDepth = ColorDepth.Depth32Bit;
            icon.ImageSize = new Size(14, 14);
            icon.Images.Add(Properties.Resources.reporte);
            //Columnas
            listView_Cotizaciones.Columns.Add("Cotización", 100, HorizontalAlignment.Center);
            listView_Cotizaciones.Columns.Add("Id cliente", 0);
            listView_Cotizaciones.Columns.Add("Cliente", 400);
            listView_Cotizaciones.Columns.Add("Ruc", 90);
            listView_Cotizaciones.Columns.Add("Cantidad locales", 100, HorizontalAlignment.Center);
            listView_Cotizaciones.Columns.Add("Creado por", 80);
            listView_Cotizaciones.Columns.Add("Fecha de creación", 150);
            listView_Cotizaciones.View = View.Details;
            listView_Cotizaciones.FullRowSelect = true;
            listView_Cotizaciones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            listView_Cotizaciones.ForeColor = Color.FromArgb(36,39,41);
        }

        private void frm_01_Load(object sender, EventArgs e)
        {
            Habilitar_Buffer_doble_control_listview(listView_Cotizaciones, true);
        }

        private void Habilitar_Buffer_doble_control_listview(ListView listview, bool v)
        {
            typeof(ListView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            listview, new object[] { true });
        }
        void Form_Nueva_Cotizacion_Show()
        {
            frm_01_1 frm_01_1 = new frm_01_1(null);
            frm_01_1.ShowDialog();

            if (frm_01_1.DialogResult == DialogResult.OK)
            {
                frm_01_2 F2 = new frm_01_2(frm_01_1._entity);
                Obtener_Cotizaciones();
                F2.ShowDialog();
            }

            txt_cliente.Focus();
        }

        void Obtener_Cotizaciones()
        {
            DateTime fecha_inicio = new DateTime(dtp_fecha_inicio.Value.Year, dtp_fecha_inicio.Value.Month, dtp_fecha_inicio.Value.Day);
            DateTime fecha_fin = new DateTime(dtp_fecha_fin.Value.Year, dtp_fecha_fin.Value.Month, dtp_fecha_fin.Value.Day, hour: 23, minute: 59, second: 29);
            _et_m39._filtro = txt_cliente.Text;
            _et_m39._fecha_Inicio = fecha_inicio;
            _et_m39._fecha_Fin = fecha_fin;
            _nt_m39.Agregar_Et_m39(_et_m39);
            _nt_m39.Iniciar(Tarea.LISTAR);
        }
        void PreLoad(bool enable)
        {
            if (enable)
            {
                lbl_status.Text = "Cargando...";
                listView_Cotizaciones.Cursor = Cursors.WaitCursor;
            }
            else
            {
                lbl_status.Text = "Listo!";
                listView_Cotizaciones.Cursor = Cursors.Arrow;
            }

        }
        #endregion

        #region Eventos
        public void Mensaje_Info(object sender, ET_entidad e)
        {
            MessageBox.Show
            (
                e._contenido_mensaje, e._titulo_mensaje,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        public void Cargar_explorador_De_cotizaciones(object sender , ET_entidad e)
        {
            if (!e._hubo_error && e._lista_et_m39!=null)
            {
                listView_Cotizaciones.Items.Clear();
                listView_Cotizaciones.SmallImageList = icon;

                int index = 0;
                foreach (ET_M39 fila in e._lista_et_m39)
                {
                    string[] row =
                    {
                        string.Format("  {0}",fila._TM39_ID),
                        fila._entity_et_m19._TM19_ID,
                        fila._entity_et_m19._TM19_DESCRIP2,
                        fila._entity_et_m19._TM19_DESCRIP1,
                        fila._TM39_tm27_count.ToString(),
                        fila._TM39_UCREA,
                        //fila._TM39_FCREA.ToString("dd/MM/yyyy"),
                        fila._TM39_FCREA.ToString("dd/MM/yyyy    hh:mm tt"),
                        //fila._TM39_FCREA.ToString("hh:mm tt"),
                        fila._TM39_FACTUALIZA.ToString()
                    };
                    listView_Cotizaciones.Items.Add(new ListViewItem(row));
                    listView_Cotizaciones.Items[index].ImageIndex = 0;
                    index++;
                }

                int items_count = Convert.ToInt32(listView_Cotizaciones.Items.Count);
                switch (items_count)
                {
                    case 1: lbl_info_list.Text = string.Format("{0} cotización", items_count); break;
                    default: lbl_info_list.Text = string.Format("{0} cotizaciones", items_count); break;
                }
            }
        }
        public void Porcentaje_De_carga(object sender, int e)
        {
            if (e == 0)
                PreLoad(true);
            else
                PreLoad(false);
        }
        private void btnNuevoCotizacion_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            Form_Nueva_Cotizacion_Show();
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {
            Obtener_Cotizaciones();
            btn_limpiar_filtro.Enabled = true;
        }

        private void listView_Cotizaciones_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Metodo_abrir_cotizacion();
        }

        private void Metodo_abrir_cotizacion()
        {
            string codigo_cotizacion = listView_Cotizaciones.SelectedItems[0].SubItems[0].Text.Trim();
            string codigo_cliente = listView_Cotizaciones.SelectedItems[0].SubItems[1].Text;
            string descripcion_cliente = listView_Cotizaciones.SelectedItems[0].SubItems[2].Text;

            Entidad_ = new ET_entidad();
            Entidad_._entity_m39._TM39_ID = codigo_cotizacion;
            Entidad_._entity_m39._entity_et_m19._TM19_ID = codigo_cliente;
            Entidad_._entity_m39._entity_et_m19._TM19_DESCRIP2 = descripcion_cliente; //razon social

            frm_01_2 F2 = new frm_01_2(Entidad_, true);
            //Obtener_Cotizaciones();
            F2.ShowDialog();
        }

        private void btn_limpiar_filtro_Click(object sender, EventArgs e)
        {
            dtp_fecha_fin.Text =Convert.ToString(DateTime.Today);
            dtp_fecha_inicio.Value = dtp_fecha_fin.Value.AddMonths(-1);
            txt_cliente.Focus();
            txt_cliente.Text = string.Empty;
            Obtener_Cotizaciones();
            btn_limpiar_filtro.Enabled = false;
        }

        private void txt_cliente_TextChanged(object sender, EventArgs e)
        {
            cliente_or_ruc = txt_cliente.Text;
        }

        private void txt_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Obtener_Cotizaciones();
                btn_limpiar_filtro.Enabled = true;
            }
        }

        private void listView_Cotizaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listView_Cotizaciones_MouseDoubleClick(null, null);
            }
        }

        #endregion

        private void listView_Cotizaciones_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Metodo_abrir_cotizacion();
            }
        }
    }

}
