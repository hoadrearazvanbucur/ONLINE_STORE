using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Frontend
{
    class ControlCard : Panel
    {
        private string name;
        private string image;
        private double price;
        private int stock;
        private string numeTelefon;
        private int id;

        public ControlCard(int idProdus, string name, string image, double price, int stock, string numeTelefon)
        {
            this.name = name;
            this.image = image;
            this.price = price;
            this.stock = stock;
            this.numeTelefon = numeTelefon;
            this.id = idProdus;
            layoutPanel();
            layouts();
        }

        public void layoutPanel()
        {
            this.Size = new Size(200, 370);
            this.BackColor = SystemColors.ControlLightLight;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void layouts()
        {
            PictureBox imagine = new PictureBox();
            layoutImagine(imagine);
            this.Controls.Add(imagine);

            Label descriere = new Label();
            layoutDescriere(descriere);
            this.Controls.Add(descriere);

            Label price = new Label();
            layoutPrice(price);
            this.Controls.Add(price);

            Label oldPrice = new Label();
            layoutOldPrice(oldPrice);
            this.Controls.Add(oldPrice);

            Label stock = new Label();
            layoutStock(stock);
            this.Controls.Add(stock);

            Button adaugaInCos = new Button();
            layoutAdaugaInCos(adaugaInCos);
            this.Controls.Add(adaugaInCos);
        }

        public void layoutImagine(PictureBox imagine)
        {
            imagine.Location = new Point(0, 0);
            imagine.Size = new Size(200, 170);
            Image im = Image.FromFile(Application.StartupPath + @"\images\" + this.image+ ".png");
            imagine.Cursor = Cursors.Hand;
            imagine.BackgroundImage = im;
            imagine.BackgroundImageLayout = ImageLayout.Stretch;
            imagine.Click += new EventHandler(produs_Click);
        }

        public void layoutDescriere(Label descriere)
        {
            descriere.AutoSize = false;
            descriere.Location = new Point(0, 170);
            descriere.Size = new Size(200, 50);
            descriere.Font = new Font("Cambria", 15, FontStyle.Regular);
            descriere.BackColor = SystemColors.ControlLightLight;
            descriere.Text = this.name + " " + this.numeTelefon;
            descriere.TextAlign = ContentAlignment.MiddleCenter;
            descriere.Cursor = Cursors.Hand;
            descriere.Click += new EventHandler(produs_Click);
        }

        public void layoutStock(Label stock)
        {
            stock.AutoSize = false;
            stock.Location = new Point(0, 220);
            stock.Size = new Size(200, 40);
            stock.Font = new Font("Cambria", 12, FontStyle.Regular);
            stock.BackColor = SystemColors.ControlLightLight;
            stock.ForeColor = Color.Green;
            if (this.stock > 0)
                stock.Text = "In stoc (" + this.stock.ToString() + ")";
            else
            {
                stock.ForeColor = Color.Red;
                stock.Text = "Stoc epuizat";
            }
            stock.TextAlign = ContentAlignment.MiddleCenter;
            stock.Cursor = Cursors.Hand;
            stock.Click += new EventHandler(produs_Click);
        }

        public void layoutOldPrice(Label oldPrice)
        {
            oldPrice.AutoSize = false;
            oldPrice.Location = new Point(0, 260);
            oldPrice.Size = new Size(200, 20);
            oldPrice.Font = new Font("Cambria", 12, FontStyle.Regular | FontStyle.Strikeout | FontStyle.Italic);
            oldPrice.BackColor = SystemColors.ControlLightLight;
            oldPrice.ForeColor = Color.Gray;
            oldPrice.Text = ((double)((3 * this.price) / 10 + this.price)).ToString() + " Lei";
            oldPrice.TextAlign = ContentAlignment.MiddleCenter;
            oldPrice.Cursor = Cursors.Hand;
            if (this.stock <= 0)
                oldPrice.Text = "";
            oldPrice.Click += new EventHandler(produs_Click);

        }

        public void layoutPrice(Label price)
        {
            price.AutoSize = false;
            price.Location = new Point(0, 280);
            price.Size = new Size(200, 50);
            price.Font = new Font("Cambria", 16, FontStyle.Regular | FontStyle.Bold);
            price.BackColor = SystemColors.ControlLightLight;
            price.ForeColor = Color.Red;
            price.Text = this.price.ToString() + " Lei";
            price.TextAlign = ContentAlignment.TopCenter;
            price.Cursor = Cursors.Hand;
            if (this.stock <= 0)
            {
                price.ForeColor = Color.Gray;
                price.Font = new Font("Cambria", 16, FontStyle.Regular | FontStyle.Strikeout | FontStyle.Bold);
            }
            price.Click += new EventHandler(produs_Click);
        }

        public void layoutAdaugaInCos(Button adaugaInCos)
        {
            adaugaInCos.Text = "Adauga in cos";
            adaugaInCos.Name = "cos," + id;
            adaugaInCos.Font = new Font("Cambria", 16, FontStyle.Bold);
            adaugaInCos.BackColor = Color.Transparent;
            adaugaInCos.Location = new Point(-1, 330);
            adaugaInCos.Size = new Size(200, 40);
            adaugaInCos.Cursor = Cursors.Hand;
            //adaugaInCos.Click += adaugaInCos_Click;
        }
        public void adaugaInCos_Click(object sender,EventArgs e)
        {
            MessageBox.Show(this.price.ToString());
        }

        public void produs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Acest produs este: " + this.name + " " + this.numeTelefon);
        }
    }
}
