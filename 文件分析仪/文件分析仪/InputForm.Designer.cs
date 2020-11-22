namespace 文件分析仪
{
    partial class InputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxInputLine = new System.Windows.Forms.TextBox();
            this.textBoxTips = new System.Windows.Forms.TextBox();
            this.labelHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(424, 180);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(331, 180);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxInputLine
            // 
            this.textBoxInputLine.Location = new System.Drawing.Point(12, 77);
            this.textBoxInputLine.Multiline = true;
            this.textBoxInputLine.Name = "textBoxInputLine";
            this.textBoxInputLine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInputLine.Size = new System.Drawing.Size(490, 97);
            this.textBoxInputLine.TabIndex = 2;
            this.textBoxInputLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxInputLine_KeyDown);
            // 
            // textBoxTips
            // 
            this.textBoxTips.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTips.Location = new System.Drawing.Point(13, 11);
            this.textBoxTips.Multiline = true;
            this.textBoxTips.Name = "textBoxTips";
            this.textBoxTips.ReadOnly = true;
            this.textBoxTips.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTips.Size = new System.Drawing.Size(490, 51);
            this.textBoxTips.TabIndex = 3;
            this.textBoxTips.Text = "请输入：";
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(13, 187);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(233, 15);
            this.labelHelp.TabIndex = 4;
            this.labelHelp.Text = "Enter换行，Ctrl+Enter等价于OK";
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 213);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.textBoxTips);
            this.Controls.Add(this.textBoxInputLine);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputForm";
            this.Text = "输入框";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxInputLine;
        private System.Windows.Forms.TextBox textBoxTips;
        private System.Windows.Forms.Label labelHelp;
    }
}