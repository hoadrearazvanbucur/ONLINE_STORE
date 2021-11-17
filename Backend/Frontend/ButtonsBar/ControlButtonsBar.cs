using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Backend.Class;

namespace Frontend
{
    public class ControlButtonsBar : Panel
    {
        private Form form;
        private Order order;
        private Customer customer;
        public ControlButtonsBar(Form form,Order order,Customer customer)
        {
            this.form = form;
            this.order = order;
            this.customer = customer;
            layoutPanel();
            layouts();
        }

        public void layoutPanel()
        {
            this.Size = new Size(1200, 40);
            this.BackColor = Color.DarkRed;
            this.BorderStyle = BorderStyle.None;
        }

        public void layouts()
        {
            Button produse = new Button();
            layoutProduse(produse);
            this.Controls.Add(produse);

            Button promotii = new Button();
            layoutPromotii(promotii);
            this.Controls.Add(promotii);

            Button branduri = new Button();
            layoutBranduri(branduri);
            this.Controls.Add(branduri);

            Button suportClienti = new Button();
            layoutSuportClienti(suportClienti);
            this.Controls.Add(suportClienti);

            Button istoricComenzi = new Button();
            layoutIstoricComenzi(istoricComenzi);
            this.Controls.Add(istoricComenzi);

            PictureBox produseP = new PictureBox();
            layoutProduseP(produseP);
            produse.Controls.Add(produseP);
        }

        public void layoutProduse(Button produse)
        {
            produse.Text = "Produse";
            produse.Font = new Font("Cambria", 16, FontStyle.Bold);
            produse.FlatStyle = FlatStyle.Popup;
            produse.BackColor = Color.Brown;
            produse.ForeColor = SystemColors.ControlLightLight;
            produse.Location = new Point(90, 0);
            produse.Size = new Size(150, 40);
            produse.Cursor = Cursors.Hand;
            produse.Click += new EventHandler(produse_Click);
        }
        public void layoutProduseP(PictureBox produseP)
        {
            produseP.Location = new Point(7, 11);
            produseP.Size = new Size(20, 20);
            Image im = Image.FromFile(Application.StartupPath + @"\images\menu.png");
            produseP.BackgroundImage = im;
            produseP.BackgroundImageLayout = ImageLayout.Stretch;
            produseP.Cursor = Cursors.Hand;
            produseP.Click += new EventHandler(produse_Click);
        }
        public void produse_Click(object sender, EventArgs e)
        {
            Panel cos = null;
            foreach (Control control in this.form.Controls)
            {
                if (control is Panel &&( control.Name.Equals("cos") == true|| control.Name.Equals("main") == true))
                    cos = control as Panel;
            }
            form.Controls.Remove(cos);

            ControlMain main = new ControlMain(order, customer, this.form,1,"");
            main.Name = "main";
            main.Location = new Point(13, 145);
            this.form.Controls.Add(main);
        }


        public void layoutPromotii(Button promotii)
        {
            promotii.Text = "Promotii";
            promotii.Font = new Font("Cambria", 16, FontStyle.Bold);
            promotii.FlatStyle = FlatStyle.Popup;
            promotii.BackColor = Color.Brown;
            promotii.Cursor = Cursors.Hand;
            promotii.ForeColor = SystemColors.ControlLightLight;
            promotii.Location = new Point(246, 0);
            promotii.Size = new Size(150, 40);
            promotii.Click += new EventHandler(promotii_Click);
        }
        public void promotii_Click(object sender, EventArgs e)
        {
            Panel cos = null;
            foreach (Control control in this.form.Controls)
            {
                if (control is Panel && (control.Name.Equals("cos") == true || control.Name.Equals("main") == true))
                    cos = control as Panel;
            }
            form.Controls.Remove(cos);

            ControlMain main = new ControlMain(order, customer, this.form,2, "");
            main.Name = "main";
            main.Location = new Point(13, 145);
            this.form.Controls.Add(main);
        }


        public void layoutBranduri(Button branduri)
        {
            branduri.Text = "Branduri";
            branduri.Font = new Font("Cambria", 16, FontStyle.Bold);
            branduri.FlatStyle = FlatStyle.Popup;
            branduri.BackColor = Color.Brown;
            branduri.Cursor = Cursors.Hand;
            branduri.ForeColor = SystemColors.ControlLightLight;
            branduri.Location = new Point(402, 0);
            branduri.Size = new Size(150, 40);
            branduri.Click += new EventHandler(branduri_Click);
        }
        public void branduri_Click(object sender, EventArgs e)
        {
            Panel cos = null;
            foreach (Control control in this.form.Controls)
            {
                if (control is Panel && (control.Name.Equals("cos") == true || control.Name.Equals("main") == true))
                    cos = control as Panel;
            }
            form.Controls.Remove(cos);

            ControlMain main = new ControlMain(order, customer, this.form, 3, "");
            main.Name = "main";
            main.Location = new Point(13, 145);
            this.form.Controls.Add(main);
        }


        public void layoutSuportClienti(Button suportClienti)
        {
            suportClienti.Text = "Suport Clienti";
            suportClienti.Font = new Font("Cambria", 16, FontStyle.Bold);
            suportClienti.FlatStyle = FlatStyle.Popup;
            suportClienti.Cursor = Cursors.Hand;
            suportClienti.BackColor = Color.Brown;
            suportClienti.ForeColor = SystemColors.ControlLightLight;
            suportClienti.Location = new Point(558, 0);
            suportClienti.Size = new Size(167, 40);
            suportClienti.Click += new EventHandler(suportClienti_Click);
        }
        public void suportClienti_Click(object sender, EventArgs e)
        {
            Panel cos = null;
            foreach (Control control in this.form.Controls)
            {
                if (control is Panel && (control.Name.Equals("cos") == true || control.Name.Equals("main") == true))
                    cos = control as Panel;
            }
            form.Controls.Remove(cos);

            ControlMain main = new ControlMain(order, customer, this.form, 4, "");
            main.Name = "main";
            main.Location = new Point(13, 145);
            this.form.Controls.Add(main);
        }

        public void layoutIstoricComenzi(Button istoricComenzi)
        {
            istoricComenzi.Text = "Istoric Comenzi";
            istoricComenzi.Font = new Font("Cambria", 16, FontStyle.Bold);
            istoricComenzi.FlatStyle = FlatStyle.Popup;
            istoricComenzi.Cursor = Cursors.Hand;
            istoricComenzi.BackColor = Color.Brown;
            istoricComenzi.ForeColor = SystemColors.ControlLightLight;
            istoricComenzi.Location = new Point(558 + 332, 0);
            istoricComenzi.Size = new Size(200, 40);
            istoricComenzi.Click += new EventHandler(istoricComenzi_Click);
        }
        public void istoricComenzi_Click(object sender, EventArgs e)
        {
            Panel cos = null;
            foreach (Control control in this.form.Controls)
            {
                if (control is Panel && (control.Name.Equals("cos") == true || control.Name.Equals("main") == true))
                    cos = control as Panel;
            }
            form.Controls.Remove(cos);

            ControlMain main = new ControlMain(order, customer, this.form, 6, "");
            main.Name = "main";
            main.Location = new Point(13, 145);
            this.form.Controls.Add(main);
        }

    }
}
