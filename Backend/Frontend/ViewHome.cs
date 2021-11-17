using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Backend.Class;
using Backend.Controller;

namespace Frontend
{
    public class ViewHome : Form
    { 
        private Panel header,buttonsBar,main;

        public ViewHome()
        {
            this.header = new Panel();
            this.buttonsBar = new Panel();
            this.main = new Panel();
            layoutForm();
            layoutPanels();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ViewHome
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ViewHome";
            this.Load += new System.EventHandler(this.ViewHome_Load);
            this.ResumeLayout(false);

        }

        private void ViewHome_Load(object sender, EventArgs e)
        {

        }

        public void layoutForm()
        {
            this.Name = "form";
            this.Size = new Size(400, 500);
            this.MaximumSize = new Size(400, 500);
            this.MinimumSize = new Size(400, 500);
            this.StartPosition = FormStartPosition.Manual;
            this.Left = Screen.PrimaryScreen.Bounds.Width/2-200;
            this.Top = Screen.PrimaryScreen.Bounds.Height/2-250;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = SystemColors.ControlLightLight;
        }

        public void layoutPanels()
        {
            ControlConectare controlConectare = new ControlConectare(this);
        }
    }
}
