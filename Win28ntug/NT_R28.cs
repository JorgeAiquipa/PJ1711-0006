using System;
using System.ComponentModel;
using Win28etug;
using Win32dtug;

namespace Win28ntug
{
    public class NT_R28 : NT_tareas
    {
        ET_globales Globales = new ET_globales();
        ET_entidad Resultado = new ET_entidad();
        ET_entidad _entidad = new ET_entidad();
        ET_R28 _et_r28 = new ET_R28();
        DT_R28 _dt_r28 = new DT_R28();

        #region Métodos
        //Registramos el servicio seleccionado para una cotizacion
        public ET_entidad set_002(ET_entidad objEntity)
        {
            return _dt_r28.set_002(objEntity._entity_r28); // aqui se registran los hijos de de un servicio padre asociado a una cotizacion
        }

        //public ET_entidad set_003(ET_entidad objEntity)
        //{
        //    return _dt_r28.set_003(objEntity._entity_r28); // aqui se cambia el flg eliminado
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
        public void Et_r28(ET_R28 dato)
        {
            if (dato != null)
            {
                _et_r28 = dato;
            }
        }
        #endregion

        #region Eventos
        protected virtual void Cargar_explorador_De_Servicios(ET_entidad e)
        {
            Cargar_explorador_De_Servicios_?.Invoke(this, e);
        }
        public event EventHandler<ET_entidad> Cargar_explorador_De_Servicios_;
        protected virtual void Eliminar_Servicio_Explorador(ET_entidad e)
        {
            Eliminar_Servicio_Explorador_?.Invoke(this, e);
        }
        public event EventHandler<ET_entidad> Eliminar_Servicio_Explorador_;
        #endregion

        #region BackgroundWorker
        BackgroundWorker bw = new BackgroundWorker();
        string Tarea_;
        public NT_R28()
        {
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
            ////bw.ReportProgress(/*####*/);
            switch (Tarea_)
            {
                case "LISTAR":
                    Resultado = new ET_entidad();
                    Resultado = _dt_r28.get_001(_et_r28._TR28_TM39_ID, Globales._TM2_ID);
                    break;
                case "ELIMINAR":
                    Resultado = new ET_entidad();
                    Resultado = _dt_r28.set_003(_et_r28._TR28_ID, _et_r28._TR28_TM39_ID, Globales._TM2_ID);
                    break;
            }

        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var percent = e.ProgressPercentage;
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
                            Cargar_explorador_De_Servicios(Resultado);
                            break;
                        case "ELIMINAR"://diego
                            Eliminar_Servicio_Explorador(Resultado);
                            break;
                    }

                }

            }


        }
        #endregion

    }
}
