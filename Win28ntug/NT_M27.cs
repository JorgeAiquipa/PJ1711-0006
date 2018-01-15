using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;
using Win32dtug;
namespace Win28ntug
{
    public class NT_M27:NT_tareas
    {
        ET_entidad _entidad = new ET_entidad();
        ET_entidad Resultado = new ET_entidad();
        ET_M19 _et_m19 = new ET_M19();
        DT_M27 _dtm27 = new DT_M27();

        public ET_entidad obtener_locales_por_cliente(ET_M19 objEntity)
        {
            return _dtm27.sel_001(objEntity);
        }

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
        public void Agregar_Et_m19(ET_M19 dato)
        {
            if (dato != null)
                _et_m19 = dato;
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
        public NT_M27()
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
                    Resultado = obtener_locales_por_cliente(_et_m19);
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
