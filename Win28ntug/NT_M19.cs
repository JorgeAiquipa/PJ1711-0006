using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Win28etug;
using Win32dtug;

namespace Win28ntug
{
    public class NT_M19 :NT_tareas //: ET_generic<ET_M19>
    {
        ET_entidad Resultado = new ET_entidad();
        ET_entidad _entidad = new ET_entidad();
        ET_M19 _et_m19;
        ET_M27 _et_m27;
        List<ET_M19> _lista_m19 = new List<ET_M19>();
        List<ET_M27> _lista_m27 = new List<ET_M27>();

        DT_M19 _dt_m19 = new DT_M19();
        object locker = new object();
        public void txt_autocomplete(TextBox _textbox)
        {
            var result = _dt_m19.get_001(_textbox.Text);

            if (!result._hubo_error)
            {
                _lista_m19 = result._lista_et_m19.ToList();
                foreach (ET_M19 row in result._lista_et_m19.ToList())
                {
                    _textbox.AutoCompleteCustomSource.Add(row._TM19_DESCRIP2);
                }
              
            }
            else
            {
                _entidad._contenido_mensaje = result._contenido_mensaje;
                Mensaje_Alerta_(_entidad);
            }


        }
        #region Métodos

        public ET_M19 sel_001(string cliente)
        {
            _et_m19 = new ET_M19();

            try
            {
                var where_lista = _lista_m19.Where(p => String.Equals(p._TM19_DESCRIP2, cliente.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();// p._TM19_DESCRIP2 == cliente).ToList();
                foreach (ET_M19 unique_row in where_lista)
                {
                    _et_m19._TM19_ID = unique_row._TM19_ID;
                    _et_m19._TM19_DESCRIP1 = unique_row._TM19_DESCRIP1;
                    _et_m19._TM19_DESCRIP2 = unique_row._TM19_DESCRIP2;
                    _et_m19._TM19_TM2_ID = unique_row._TM19_TM2_ID;
                }
            }
            catch (Exception ex)
            { }

            if (string.IsNullOrEmpty(_et_m19._TM19_ID))
            {
                _entidad._hubo_error = true;
                _entidad._titulo_mensaje = "Alerta";
                string msg = string.Format("El cliente ingresado no existe.");
                _entidad._contenido_mensaje = msg;
                Mensaje_Alerta_(_entidad);
            }
            return _et_m19;
        }

        ////BUSCAR CLIENTE
        //public List<ET_M19> sel_002(string filtro_)
        //{
        //    return _dt_m19.get_001(filtro_)._lista_et_m19;
        //}
        #endregion


        #region Mensajes
        protected virtual void Mensaje_Alerta_(ET_entidad e)
        {
            Mensaje_Alerta?.Invoke(this, e);
        }
        public event EventHandler<ET_entidad> Mensaje_Alerta;
        protected virtual void Mensaje_Info_(ET_entidad e)
        {
            Mensaje_Info?.Invoke(this, e);
        }
        public event EventHandler<ET_entidad> Mensaje_Info;
        protected virtual void Mensaje_Confir_(ET_entidad e)
        {
            Mensaje_Confir?.Invoke(this, e);
        }
        public event EventHandler<ET_entidad> Mensaje_Confir;
        protected virtual void Mensaje_Error_(ET_entidad e)
        {
            Mensaje_Error?.Invoke(this, e);
        }
        public event EventHandler<ET_entidad> Mensaje_Error;
        #endregion

        #region Agregaciones
        public void _Filtro(string dato)
        {
            if (!string.IsNullOrEmpty(dato))
            {
                _entidad._Filtro = dato;
            }
        }
        #endregion

        #region Eventos
        protected virtual void Cargar_busqueda(ET_entidad e)
        {
            Cargar_busqueda_?.Invoke(this, e);
        }
        public event EventHandler<ET_entidad> Cargar_busqueda_;
        protected virtual void Porcentaje_De_Craga_(int e)
        {
            Porcentaje_De_Craga?.Invoke(this, e);
        }
        public event EventHandler<int> Porcentaje_De_Craga;
        #endregion

        #region BackgroundWorker
        BackgroundWorker bw = new BackgroundWorker();
        string Tarea_;

        public NT_M19()
        {
            //Eventos
            bw.WorkerReportsProgress = true;
            bw.DoWork += Bw_DoWork;
            bw.ProgressChanged += Bw_ProgressChanged;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
        }
        public void Iniciar(Func<string> TAREA)
        {
            Tarea_ = TAREA(); 
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            bw.ReportProgress(0);
            switch (Tarea_)
            {
                case "BUSCAR":
                    Resultado = _dt_m19.get_001(_entidad._Filtro);
                    break;
            }
            bw.ReportProgress(100);
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //mostrar este valor en un ProgressBar
            var percent = e.ProgressPercentage;
            Porcentaje_De_Craga_(percent);
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
            }
            else if (e.Error != null)
            {
            }
            else
            {

                if (Resultado._hubo_error)
                {
                    Mensaje_Info_(Resultado);
                }
                else
                {
                    switch (Tarea_)
                    {
                        case "BUSCAR":
                            Cargar_busqueda(Resultado);
                            break;
                    }

                }

            }


        }
        #endregion


    }
}
