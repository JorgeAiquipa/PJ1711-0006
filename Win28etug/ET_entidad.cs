/**
 * Description: daoConexion.
 * Version: 1.0.0
 * Last update: 2017/12/11
 * Author: User Name <cesar.freitas@actecperu.com>
 *
   ========================================================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win28etug
{
    public delegate void MensajeEventHandler(Object sender, ET_entidad e);
    public class ET_entidad: EventArgs
    {
        public string _titulo_mensaje { get; set; }
        public string _contenido_mensaje { get; set; }
        public bool _hubo_error { get; set; }

        public List<ET_servicio> _servicio { get; set; }


        public List<ET_M19> _lista_et_m19 { get; set; }
        public List<ET_M27> _lista_et_m27 { get; set; }
        public List<ET_M41> _lista_et_m41 { get; set; }
        public List<ET_M38> _lista_et_m38 { get; set; }


        public ET_M19 _entity_m19 { get; set; }
        public ET_M41 _entity_m41 { get; set; }
    }
    public interface ET_generic<T>
    {
        //LISTAR
        List<T> get_list();
        //FILTRAR
        List<T> filter_list(T objEntity);
        //BUSCAR SELECCIONAR
        T search(T objEntity);
        //INSERTAR
        bool insert_01(T objEntity);
        //ACTUALIZAR
        bool update_01(T objEntity);
        //BORRAR
        bool delete_01(T objEntity);

    }


}
