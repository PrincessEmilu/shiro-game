using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace levelEditor
{
    public class MapPanel : Panel
    {
        //Properties
        public int tileID { get; set; }
        public bool isCollision { get; set; }
    }
}
