﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win28etug;
using Win32dtug;

namespace Win28ntug
{
    public class NT_R28
    {
        ET_entidad _entidad = new ET_entidad();
        ET_R28 _et_r28 = new ET_R28();
        DT_R28 _dt_r28 = new DT_R28();

        //Registramos el servicio seleccionado para una cotizacion
        public ET_entidad set_002(ET_entidad objEntity)
        {
            return _dt_r28.set_002(objEntity._entity_r28); // aqui se registran los hijos de de un servicio padre asociado a una cotizacion
        }

        //obtenemos los servicios de una cotización
        public void get_001(ET_entidad entity, TreeView treview) 
        {
            entity._entity_r28._TR28_TM39_ID = entity._entity_m39._TM39_ID;
            var result = _dt_r28.get_001(entity._entity_r28);

            if (!result._hubo_error && result._lista_et_r28.Count > 0)
            {
                TreeNode mano_obra = new TreeNode("Mano de Obra");
                mano_obra.Name = "Mano de Obra";
                mano_obra.Tag = 0;
                TreeNode maquinaria = new TreeNode("Maquinaria y Equipo");
                maquinaria.Tag = 1;
                TreeNode materiales = new TreeNode("Materiales e Insumos");
                materiales.Tag = 2;
                TreeNode implementos = new TreeNode("Implementos de Limpieza");
                implementos.Tag = 3;
                TreeNode suministros = new TreeNode("Suministros");
                suministros.Tag = 4;
                TreeNode indumentaria = new TreeNode("Indumentaria");
                indumentaria.Tag = 5;

                string name_nodo = string.Format("{0} - {1}", entity._entity_m39._TM39_ID, entity._entity_m39._entity_et_m19._TM19_DESCRIP2);
                TreeNode nodo_principal = new TreeNode();
                nodo_principal.Tag = 10100;
                nodo_principal.Name = name_nodo;
                nodo_principal.Text = name_nodo;

                int z_index = 1000;

                result._lista_et_r28.ForEach(x =>
                {
                    TreeNode node = new TreeNode(x._TR28_DESCRIP, new TreeNode[] {
                        mano_obra,maquinaria,materiales,implementos,suministros,indumentaria
                    });
                    node.Name = x._TR28_DESCRIP;
                    node.Tag = 1000;
                    z_index++;

                    nodo_principal.Nodes.Add(node);
                });

                nodo_principal.ExpandAll();

                treview.Nodes.Add(nodo_principal);
            }
        }
        
    }
}