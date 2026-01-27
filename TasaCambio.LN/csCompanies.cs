using System.Windows.Forms;

namespace LN
{
    public class csCompanies
    {
        public string codeDB { get; set; }
        public string nameDB { get; set; }
        public CheckBox checkBoxDB { get; set; }

        public csCompanies(string _codeDB, string _nameDB, CheckBox _checkBoxDB)
        {
            codeDB = _codeDB;
            nameDB = _nameDB;
            checkBoxDB = _checkBoxDB;
        }
    }
}
