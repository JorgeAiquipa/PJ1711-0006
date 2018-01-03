using System;
using System.Collections.Generic;
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
        #region Métodos

        //registramos la configuracion de mano de obra 
        public void set_001(List<ET_R29> cargos_, List<ET_R27> locales_)
        {
            int indice = 0;
            locales_.ForEach(local=> {


                cargos_.ForEach(cargo=> {

                    int canti = cargo._Locales_por_cargo_cantidad_personal[indice];
                    ET_R31 parametros = new ET_R31();
                    parametros._TR31_TM2_ID = Globales._TM2_ID;
                    parametros._TR31_DESCRIP = "Hey!";
                    parametros._TR31_UCREA = Globales._U_CREA;
                    parametros._TR31_TM2_ID = Globales._TM2_ID;
                    parametros._TR31_TR29_ID = cargo._TR29_ID;
                    parametros._TR31_TR28_ID = cargo._TR29_TR28_ID;
                    parametros._TR31_TR27_ID = local._TR27_ID;
                    parametros._TR31_CANT_PERSONAS = canti;
                    _dt_R31.set_001(parametros);
                });

                indice++;

            });
        }

        public List<ET_R31> get_001(int tr_29_id)
        {
            ET_R31 parametros = new ET_R31();
            parametros._TR31_TM2_ID = Globales._TM2_ID;
            parametros._TR31_TR28_ID = tr_29_id;

            return _dt_R31.sel_001(parametros)._lista_et_r31;
        }
        #endregion

        #region Mensajes
        #endregion

        #region Agregaciones
        #endregion

        #region Eventos
        #endregion

        #region BackgroundWorker

        #endregion
    }
}
