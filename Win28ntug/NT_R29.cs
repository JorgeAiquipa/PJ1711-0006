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
    public class NT_R29 : NT_tareas
    {
        ET_entidad Resultado = new ET_entidad();
        ET_entidad _et_entidad = new ET_entidad();
        ET_globales Globales = new ET_globales();
        ET_R29 _ETR29 = new ET_R29();
        NT_M40 _NT_M40 = new NT_M40();
        DT_R29 _dt_r29 = new DT_R29();
        DT_R30 _dt_r30 = new DT_R30();


        #region Métodos
        public ET_entidad get_001(ET_R29 obj)
        {
            // obj._lista_et_m40; --> conceptos remunerativos disponibles
            var resultado = _dt_r29.get_001(obj);
            // analizamos los conceptos remunerativos que posee cada cargo y seleccionamos los conceptos que se visualizara como seleccionado
            List<ET_R29> lista_final = new List<ET_R29>();
            int fila_ = 0;

            resultado._lista_et_r29.ForEach(row => {
                ET_R29 _entidad_final = new ET_R29();
                List<ET_M40> _lista_child_etm40 = new List<ET_M40>();
                foreach (ET_M40 row_c in obj._lista_et_m40)
                {

                    ET_M40 entidad_m40 = new ET_M40();

                    var where_on_list_et_r30 = row._lista_et_r30.FirstOrDefault(x => x._TR30_TM40_ID == row_c._TM40_ID && x._TR30_DESCRIP == row_c._TM40_DESCRIP);
                    if (where_on_list_et_r30 != null)
                        entidad_m40._Seleccionado = true;
                    else
                        entidad_m40._Seleccionado = false;

                    entidad_m40._TM40_DESCRIP = row_c._TM40_DESCRIP;
                    entidad_m40._TM40_ID = row_c._TM40_ID;
                    entidad_m40._fila = fila_;
                    entidad_m40._Work = row_c._Work;
                    entidad_m40._TM40_IMPORTE = row_c._TM40_IMPORTE;
                    entidad_m40._TM40_PORCENTAJE = row_c._TM40_PORCENTAJE;

                    _lista_child_etm40.Add(entidad_m40);
                }
                _entidad_final._Fila = fila_;
                _entidad_final._TR29_DESCRIP = row._TR29_DESCRIP;
                _entidad_final._TR29_DIAS_SEMANA = row._TR29_DIAS_SEMANA;
                _entidad_final._TR29_HORA_ENTRADA = row._TR29_HORA_ENTRADA;
                _entidad_final._TR29_HORA_SALIDA = row._TR29_HORA_SALIDA;
                _entidad_final._TR29_ID = row._TR29_ID;
                _entidad_final._TR29_REMUNERACION = row._TR29_REMUNERACION;
                _entidad_final._TR29_TM2_ID = row._TR29_TM2_ID;
                _entidad_final._TR29_TM38_ID = row._TR29_TM38_ID;
                _entidad_final._TR29_TR28_ID = row._TR29_TR28_ID;
                _entidad_final._lista_et_m40 = _lista_child_etm40;
                _entidad_final._lista_et_r30 = row._lista_et_r30;
                _entidad_final._TR29_FLG_ELIMINADO = row._TR29_FLG_ELIMINADO;
                _entidad_final._TR29_ST = 1; // manejare el estado para analizar quien se actualiza y quien no que se registra y quien no lo hace
                // 1 -> obtenido desde base de datos
                // 0 -> es un nuevo ingreso

                lista_final.Add(_entidad_final);
                fila_++;

            });

            resultado._lista_et_r29 = lista_final;
            return resultado;
        }

        public int[] Metodo_Analizar_filas_repetidas(List<ET_R29> obj)
        {
            var clon_ = obj;

            int indice_repetido = 0;
            bool existe = false;
            int[] respuesta = new int[2];

            foreach (ET_R29 row in obj)
            {
                int _indice = row._Fila; // 0 ,1, 2
                string _id_Cargo = row._TR29_TM38_ID; //sup
                string _descripcion = row._TR29_DESCRIP;
                DateTime _hora_e = row._TR29_HORA_ENTRADA;
                DateTime _hora_s = row._TR29_HORA_SALIDA;
                int _dias = row._TR29_DIAS_SEMANA;
                decimal _remuneracion = row._TR29_REMUNERACION;
                List<ET_M40> _lista_De_remuneraciones = row._lista_et_m40;
                foreach (ET_R29 row_clon in clon_)
                {
                    if (row_clon._Fila != _indice)
                    {
                        if (
                                row_clon._TR29_FLG_ELIMINADO != 1 &&
                                row_clon._TR29_DESCRIP == _descripcion &&
                                row_clon._TR29_TM38_ID == _id_Cargo &&
                                row_clon._TR29_HORA_ENTRADA == _hora_e &&
                                row_clon._TR29_HORA_SALIDA == _hora_s &&
                                row_clon._TR29_DIAS_SEMANA == _dias &&
                                row_clon._TR29_REMUNERACION == _remuneracion &&
                                Comparar_conceptos_remunerativos(row_clon._lista_et_m40, _lista_De_remuneraciones) == true

                            ) { indice_repetido = row_clon._Fila; existe = true; }
                    }
                }
            }

            respuesta[0] = indice_repetido;
            respuesta[1] = Convert.ToInt32(existe);
            return respuesta;
        }
        bool Comparar_conceptos_remunerativos(List<ET_M40> lista_A, List<ET_M40> lista_B)
        {
            // COMPARAR SI A ES IGUAL A B
            bool respuesta = false;

            if (lista_B.Where(x => x._Seleccionado == true).ToList().Count != lista_A.Where(x => x._Seleccionado == true).ToList().Count)
            { return false; }
            else if ((lista_A.Count + lista_B.Count) == 0)
            { return true; }
            else
            {
                int par_mitad = lista_B.Where(X => X._Seleccionado == true).ToList().Count;
                int contador = 0;
                foreach (ET_M40 row_b in lista_B)
                {
                    foreach (ET_M40 row_a in lista_A)
                    {
                        if (row_b._TM40_ID == row_a._TM40_ID && row_b._Seleccionado == true && row_a._Seleccionado == true) { contador++; }
                    }
                }

                if (contador == par_mitad) respuesta = true;
            }
            return respuesta;

        }

        public void set_001(List<ET_R29> _lista_et_r29, List<ET_R29> _lista_et_r29_back)
        {
            _lista_et_r29_back.ForEach(row =>
            {
                if (row._TR29_FLG_ELIMINADO == 1 && row._TR29_ST == 1)
                {
                    //actualizar flg 1
                    bool respuesta = _dt_r29.set_002(row);
                }

            });

            var lista_where_r29 = _lista_et_r29.Where(X => X._TR29_ST == 1).ToList();

            lista_where_r29.ForEach(row => {

                bool respuesta = _dt_r29.set_002(row);
                int id = row._TR29_ID;
                if (respuesta)
                {
                    row._lista_et_r30.ForEach(x => {

                        ET_R30 et30 = new ET_R30();
                        et30._TR30_ID = x._TR30_ID;
                        et30._TR30_TR29_ID = x._TR30_TR29_ID;
                        et30._TR30_IMPORTE = x._TR30_IMPORTE;
                        et30._TR30_TM40_ID = x._TR30_TM40_ID;
                        et30._TR30_FLG_ELIMINADO = 1;
                        et30._TR30_TM2_ID = x._TR30_TM2_ID;
                        et30._TR30_UACTUALIZA = Globales._U_SESSION;
                        _dt_r30.set_002(et30);

                    });

                    var all_true = row._lista_et_m40.Where(x => x._Seleccionado == true).ToList();
                    foreach (ET_M40 row_child in all_true)
                    {
                        ET_R30 _et_r30 = new ET_R30();

                        _et_r30._TR30_TR29_ID = row._TR29_ID;//result._entity_r29._TR29_ID;
                        _et_r30._TR30_TM40_ID = row_child._TM40_ID;
                        _et_r30._TR30_DESCRIP = row_child._TM40_DESCRIP;
                        _et_r30._TR30_FLG_ELIMINADO = 0;
                        _et_r30._TR30_IMPORTE = row_child._Work.Equals("P") ? (row._TR29_REMUNERACION * row_child._TM40_PORCENTAJE) : (row_child._TM40_IMPORTE);
                        _dt_r30.set_001(_et_r30);
                    }

                }
            });

            _lista_et_r29.Where(X => X._TR29_ST == 0).ToList().ForEach(row => {

                //registramos lo nuevo

                DateTime h_e_ = new DateTime(year: 1900, month: 1, day: 1, hour: row._TR29_HORA_ENTRADA.Hour, minute: row._TR29_HORA_ENTRADA.Minute, second: 0); // reset
                DateTime h_s_ = new DateTime(year: 1900, month: 1, day: 1, hour: row._TR29_HORA_SALIDA.Hour, minute: row._TR29_HORA_SALIDA.Minute, second: 0); // reset


                ET_R29 _et_r29 = new ET_R29();
                _et_r29._TR29_TR28_ID = row._TR29_TR28_ID; //servicio hijo que a su ve es padre en algunos casos
                _et_r29._TR29_TM38_ID = row._TR29_TM38_ID; // id del cargo que se va a registrar

                _et_r29._TR29_HORA_ENTRADA = h_e_;
                _et_r29._TR29_HORA_SALIDA = h_s_;
                _et_r29._TR29_DIAS_SEMANA = row._TR29_DIAS_SEMANA;
                _et_r29._TR29_DESCRIP = row._TR29_DESCRIP;
                _et_r29._TR29_REMUNERACION = row._TR29_REMUNERACION;

                var result = _dt_r29.set_001(_et_r29);

                if (!result._hubo_error)
                {
                    var all_true = row._lista_et_m40.Where(x => x._Seleccionado == true).ToList();
                    foreach (ET_M40 row_child in all_true)
                    {
                        ET_R30 _et_r30 = new ET_R30();

                        _et_r30._TR30_TR29_ID = result._entity_r29._TR29_ID;
                        _et_r30._TR30_TM40_ID = row_child._TM40_ID;
                        _et_r30._TR30_DESCRIP = row_child._TM40_DESCRIP;
                        _et_r30._TR30_FLG_ELIMINADO = 0;
                        _et_r30._TR30_IMPORTE = row_child._Work.Equals("P") ? (row._TR29_REMUNERACION * row_child._TM40_PORCENTAJE) : (row_child._TM40_IMPORTE);
                        _dt_r30.set_001(_et_r30);
                    }
                }

            });
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
        public void Agregar_ETR29(ET_R29 dato)
        {
            if (dato!= null)
            {
                _ETR29 = dato;
            }
        }
        #endregion

        #region Eventos
        protected virtual void Cargar_Listado(ET_entidad e)
        {
            Cargar_Listado_?.Invoke(this, e);
        }
        public event EventHandler<ET_entidad> Cargar_Listado_;
        protected virtual void Porcentaje_De_Craga_(int e)
        {
            Porcentaje_De_Craga?.Invoke(this, e);
        }
        public event EventHandler<int> Porcentaje_De_Craga;
        #endregion

        #region BackgroundWorker
        BackgroundWorker bw = new BackgroundWorker();
        string Tarea_;

        public NT_R29()
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
                case "LISTAR":
                    Resultado = get_001(_ETR29);
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
