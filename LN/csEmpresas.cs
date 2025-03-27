using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LN
{
    public class csEmpresas
    {
        public string codigoDB { get; set; }
        public string nombreDB { get; set; }
        public CheckBox checkBoxDB { get; set; }

        public csEmpresas(string _codigoDB, string _nombreDB, CheckBox _checkBoxDB)
        {
            codigoDB = _codigoDB;
            nombreDB = _nombreDB;
            checkBoxDB = _checkBoxDB;
        }
    }
}
