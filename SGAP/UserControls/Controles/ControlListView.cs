using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGAP.UserControls
{
    public class ControlListView :ListView
    {
        public ControlListView() : base()
        {
            this.DoubleBuffered = true;
        }
    }
}
