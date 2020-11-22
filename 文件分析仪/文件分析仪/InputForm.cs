using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文件分析仪
{
    public partial class InputForm : Form
    {

        public delegate void TextEventHandler(string strText);

        public TextEventHandler TextHandler;

        public InputForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }
        public void setTips(string tips)
        {
            this.textBoxTips.Text = tips;
        }
        public void setTitle(string title)
        {
            this.Text = title;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (null != TextHandler)
            {
                TextHandler.Invoke(this.textBoxInputLine.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBoxInputLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == (Keys)e.KeyCode && e.Control==true)
            {
                if (null != TextHandler)
                {
                    TextHandler.Invoke(this.textBoxInputLine.Text);
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
