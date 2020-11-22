using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文件分析仪
{
    public class InputDialog
    {
        public static DialogResult Show(out string strText)
        {
            string strTemp = string.Empty;

            InputForm inputDialog = new InputForm();
            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp;

            return result;
        }
        public static DialogResult Show(out string strText,string tips)
        {
            string strTemp = string.Empty;

            InputForm inputDialog = new InputForm();
            inputDialog.setTips(tips);

            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp;

            return result;
        }
        public static DialogResult Show(out string strText, string tips,string caption)
        {
            string strTemp = string.Empty;

            InputForm inputDialog = new InputForm();
            inputDialog.setTips(tips);
            inputDialog.setTitle(caption);

            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp;

            return result;
        }
        public static DialogResult Show(Form owner,out string strText, string tips, string caption)
        {
            string strTemp = string.Empty;

            InputForm inputDialog = new InputForm();
            inputDialog.Owner = owner;
            inputDialog.setTips(tips);
            inputDialog.setTitle(caption);

            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp;

            return result;
        }
    }
}
