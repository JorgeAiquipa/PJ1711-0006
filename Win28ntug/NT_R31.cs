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
    public class NT_R31:NT_tareas
    {
        ET_entidad Resultado = new ET_entidad();
        ET_globales Globales = new ET_globales();

        DT_R31 _dt_R31 = new DT_R31();
        ET_R31 _et_r31 = new ET_R31();

        List<ET_R29> ET_R29_CARGOS;
        List<ET_R27> ET_R27_LOCALES;
        #region Métodos

        public int set_001(List<ET_R29> cargos_, List<ET_R27> locales_) //optimo return cero
        {
            int indice = 0;
            int elementos_sin_registrar = 0;
            locales_.ForEach(local=> {


                cargos_.ForEach(cargo=> {
                    int[] int_object = new int[2];
                    int_object = (int[])cargo._Locales_por_cargo_cantidad_personal[indice];
    
                    ET_R31 parametros = new ET_R31();
                    parametros._TR31_TM2_ID = Globales._TM2_ID;
                    parametros._TR31_DESCRIP = "insert!";
                    parametros._TR31_UCREA = Globales._U_SESSION;
                    parametros._TR31_TR29_ID = cargo._TR29_ID;
                    parametros._TR31_TR28_ID = cargo._TR29_TR28_ID;
                    parametros._TR31_TR27_ID = local._TR27_ID;
                    parametros._TR31_UACTUALIZA = Globales._U_SESSION;
                    parametros._TR31_CANT_PERSONAS = int_object[0];
                    var result_ = _dt_R31.set_001(parametros)._hubo_error;
                    if (result_)
                        elementos_sin_registrar++;
                });
                indice++;
            });
            return elementos_sin_registrar;
        }

        public List<ET_R31> get_001(int tr_29_id)
        {
            ET_R31 parametros = new ET_R31();
            parametros._TR31_TM2_ID = Globales._TM2_ID;
            parametros._TR31_TR28_ID = tr_29_id;

            return _dt_R31.sel_001(parametros)._lista_et_r31;
        }

        public ET_entidad set_002(List<ET_R29> cargos_, List<ET_R27> locales_)
        {
            Resultado = new ET_entidad();
            Resultado._hubo_error = false;
            Resultado._titulo_mensaje = "Mensaje del sistema";
            Resultado._contenido_mensaje = string.Empty;
            List<ET_R29> Cargos_nuevos = new List<ET_R29>();
            
            #region ACTUALIZAR
            int indice = 0;
            int elementos_sin_actualizar = 0;
            locales_.ForEach(local => {
                cargos_.ForEach(cargo => {
                    bool _nuevo_elemento = false;

                    foreach (int[] roe in cargo._Locales_por_cargo_cantidad_personal)
                    {

                        if (roe[1] == 0)
                        {
                            _nuevo_elemento = true;
                            break;
                        }
                        if (roe[1] != 0)
                        {
                            ET_R31 parametros = new ET_R31();
                            parametros._TR31_TM2_ID = Globales._TM2_ID;
                            parametros._TR31_DESCRIP = "update!";
                            parametros._TR31_UACTUALIZA = Globales._U_SESSION;
                            parametros._TR31_CANT_PERSONAS = roe[0];
                            parametros._TR31_ID = roe[1];
                            var result_ = _dt_R31.set_002(parametros)._hubo_error;
                            if (result_)
                                elementos_sin_actualizar++;
                        }
                    }

                    if (_nuevo_elemento)
                    {
                        ET_R29 tmp_e = new ET_R29();
                        tmp_e = cargo;
                        List<ET_R29> tmp_l = new List<ET_R29>();
                        tmp_l.Add(tmp_e);
                        Cargos_nuevos.Add(tmp_e);
                    }
                });
                indice++;
            });
            #endregion

            // SI SE ECONTRARON REGISTROS NUEVOS LOS FILTRAMOS E INGRESAMOS
            #region REGISTRAR
            int Elementos_sin_registrar = 0;
            if (Cargos_nuevos.Count > 0)
            {
                var _group_cargos = Cargos_nuevos.GroupBy(x => new
                {
                    x._Fila,
                    x._Locales_por_cargo_cantidad_personal,
                    x._TR29_DESCRIP,
                    x._TR29_DIAS_SEMANA,
                    x._TR29_ID,
                    x._TR29_TM2_ID,
                    x._TR29_TM38_ID,
                    x._TR29_TR28_ID
                }).Select(y => new ET_R29()
                        {
                            _Fila = y.Key._Fila,
                            _Locales_por_cargo_cantidad_personal = y.Key._Locales_por_cargo_cantidad_personal,
                            _TR29_DESCRIP = y.Key._TR29_DESCRIP,
                            _TR29_DIAS_SEMANA = y.Key._TR29_DIAS_SEMANA,
                            _TR29_ID = y.Key._TR29_ID,
                            _TR29_TM2_ID = y.Key._TR29_TM2_ID,
                            _TR29_TM38_ID = y.Key._TR29_TM38_ID,
                            _TR29_TR28_ID = y.Key._TR29_TR28_ID,
                        }
                    );

                List<ET_R29> lista_final = new List<ET_R29>();
                foreach (var entidad in _group_cargos)
                    lista_final.Add(entidad);
                Elementos_sin_registrar = set_001(lista_final, locales_);
            }
            #endregion

            #region Resultado
            if (Elementos_sin_registrar > 0 || elementos_sin_actualizar > 0)
            {
                Resultado._hubo_error = true;
                Resultado._contenido_mensaje = String.Format(" ELEMENTOS NO ACTUALIZADOS = {0} \n ELEMENTOS NUEVOS NO REGISTRADOS {1}", elementos_sin_actualizar, Elementos_sin_registrar); ;
            }
            if (Elementos_sin_registrar == 0 && elementos_sin_actualizar == 0)
                Resultado._contenido_mensaje = "Éxito al guardar!";
            #endregion

            return Resultado;
        }
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
        public void Argregar_ET_R29_CARGOS(List<ET_R29> dato)
        {
            if (dato != null)
            {
                ET_R29_CARGOS = dato;
            }
        }
        public void Agregar_ET_R27_LOCALES(List<ET_R27> dato)
        {
            if (dato != null)
            {
                ET_R27_LOCALES = dato;
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
        public NT_R31()
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
                case "ACTUALIZAR":
                    Resultado = set_002(ET_R29_CARGOS, ET_R27_LOCALES);
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
                        case "ACTUALIZAR":
                            if (Resultado._hubo_error)
                                Mensaje_Alerta_(Resultado);
                            else
                                Mensaje_Info_(Resultado);
                            break;
                    }

                }

            }


        }
        #endregion

    }
}
