﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

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
            this.Size = new Size(1200, 700);
            this.MaximumSize = new Size(1200, 700);
            this.MinimumSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = SystemColors.ControlLightLight;
        }

        public void layoutPanels()
        {
            ControlHeader header = new ControlHeader();
            header.Location = new Point(13, 13);
            this.Controls.Add(header);

            ControlButtonsBar bar = new ControlButtonsBar();
            bar.Location = new Point(0, 109);
            this.Controls.Add(bar);

            ControlMain main = new ControlMain();
            ////main.Location = new Point(13, 145);
            //this.Controls.Add(main);
        }



    }
}