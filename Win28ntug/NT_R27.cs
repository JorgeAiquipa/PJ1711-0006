﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;
using Win32dtug;
namespace Win28ntug
{
    public class NT_R27
    {
        DT_R27 _dt_r27 = new DT_R27();

        public ET_entidad get_001(ET_entidad entity)
        {
            return  _dt_r27.get_001(entity._entity_r27);
        }
    }
}