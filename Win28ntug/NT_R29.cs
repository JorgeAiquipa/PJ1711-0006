using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;
using Win32dtug;
namespace Win28ntug
{
    public class NT_R29
    {
        ET_entidad _et_entidad = new ET_entidad();
        DT_R29 _dt_r29 = new DT_R29();
        DT_R30 _dt_r30 = new DT_R30();
        public ET_entidad get_001(ET_R29 obj)
        {

            return _dt_r29.get_001(obj);
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

                foreach (ET_R29 row_clon in clon_)
                {
                    if (row_clon._Fila != _indice)
                    {
                        if (
                                row_clon._TR29_DESCRIP == _descripcion &&
                                row_clon._TR29_TM38_ID == _id_Cargo &&
                                row_clon._TR29_HORA_ENTRADA == _hora_e &&
                                row_clon._TR29_HORA_SALIDA == _hora_s &&
                                row_clon._TR29_DIAS_SEMANA == _dias &&
                                row_clon._TR29_REMUNERACION == _remuneracion
                            ) { indice_repetido = row_clon._Fila; existe = true; }
                    }
                }
            }

            respuesta[0] = indice_repetido;
            respuesta[1] = Convert.ToInt32(existe);
            return respuesta;
        }

        public void set_001(ET_entidad obj)
        {

            foreach (ET_R29 row in obj._lista_et_r29)
            {
                DateTime h_e_ = new DateTime(year: 1900, month: 1, day: 1, hour: row._TR29_HORA_ENTRADA.Hour, minute: row._TR29_HORA_ENTRADA.Minute,second:0); // reset
                DateTime h_s_ = new DateTime(year: 1900, month: 1, day: 1, hour: row._TR29_HORA_SALIDA.Hour, minute: row._TR29_HORA_SALIDA.Minute,second:0); // reset


                ET_R29 _et_r29 = new ET_R29();
                _et_r29._TR29_TR28_ID = row._TR29_TR28_ID;
                _et_r29._TR29_TM38_ID = row._TR29_TM38_ID;

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

                        _dt_r30.set_001(_et_r30);
                    }
                }
            }

        }
    }
}
