using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win28etug;
using Win32dtug;
using System.ComponentModel;

namespace Win28ntug
{
    public class NT_M40
    {

        ET_entidad Resultado = new ET_entidad();
        ET_entidad _entidad = new ET_entidad();
        DT_M40 _dt_m40 = new DT_M40();
        ET_M40 _et_m40 = new ET_M40();

        //obtenemos los conceptos remunerativos disponibles
        public ET_entidad get_001()
        {
            return _dt_m40.get_001();
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

        #endregion

        #region Eventos
        protected virtual void Cargar_Listado(ET_entidad e)
        {
            Cargar_Listado_?.Invoke(this, e);
        }
        public event EventHandler<ET_entidad> Cargar_Listado_;
        protected virtual void Porcentaje_De_Carga_(int e)
        {
            Porcentaje_De_Carga?.Invoke(this, e);
        }
        public event EventHandler<int> Porcentaje_De_Carga;
        #endregion

        #region BackgroundWorker
        BackgroundWorker bw = new BackgroundWorker();
        string Tarea_;

        public NT_M40()
        {
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
                case "LISTAR":
                    Resultado = get_001();
                    break;
            }
            bw.ReportProgress(100);
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //mostrar este valor en un ProgressBar
            var percent = e.ProgressPercentage;
            Porcentaje_De_Carga_(percent);
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
                        case "LISTAR":
                            Cargar_Listado(Resultado);
                            break;
                    }

                }

            }


        }
        #endregion
    }
}
