using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Frontend
{
    public class ControlComanda : Panel
    {
        private string name;
        private string image;
        private int stock;
        private double price;
        private string numeTelefon;

        public ControlComanda(string name, string image, double price, string numeTelefon, int stock)
        {
            this.name = name;
            this.image = image;
            this.price = price;
            this.stock = stock;
            this.numeTelefon = numeTelefon;
            layoutPanel();
            layouts();
        }

        public void layoutPanel()
        {
            this.Size = new Size(635, 150);
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

            Button stockM = new Button();
            layoutStockM(stockM);
            this.Controls.Add(stockM);

            Label stockC = new Label();
            layoutStockC(stockC);
            this.Controls.Add(stockC);

            Button stockP = new Button();
            layoutStockP(stockP);
            this.Controls.Add(stockP);

            Label stergere = new Label();
            layoutStergere(stergere);
            this.Controls.Add(stergere);


        }

        public void layoutStockM(Button stockM)
        {
            stockM.Text = "-";
            stockM.Font = new Font("Cambria", 12, FontStyle.Bold);
            stockM.BackColor = Color.Transparent;
            stockM.Location = new Point(400, 70);
            stockM.Size = new Size(30, 30);
            stockM.Cursor = Cursors.Hand;
            stockM.BackColor = Color.Brown;
            stockM.Click += new EventHandler(stockM_Click);
        }

        public void layoutStockC(Label stockC)
        {
            stockC.AutoSize = false;
            stockC.Name = "stock";
            stockC.Location = new Point(430, 70);
            stockC.Size = new Size(60, 30);
            stockC.Font = new Font("Cambria", 18, FontStyle.Regular);
            stockC.BackColor = SystemColors.ControlLightLight;
            stockC.TextAlign = ContentAlignment.MiddleCenter;
            stockC.Text = "1";
        }


        public void layoutStockP(Button stockP)
        {
            stockP.Text = "+";
            stockP.Font = new Font("Cambria", 12, FontStyle.Bold);
            stockP.BackColor = Color.Transparent;
            stockP.Location = new Point(490, 70);
            stockP.Size = new Size(30, 30);
            stockP.Cursor = Cursors.Hand;
            stockP.BackColor = Color.Brown;
            stockP.Click += new EventHandler(stockP_Click);

        }
        public void stockM_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Label && (c as Label).Name == "stock")
                {
                    int nr = int.Parse((c as Label).Text);
                    nr--;
                    if (nr <= 0)
                        (c as Label).Text = "1";
                    else
                        (c as Label).Text = nr.ToString();
                }
            }
        }

        public void stockP_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {

                if (c is Label && (c as Label).Name == "stock")
                {
                    int nr = int.Parse((c as Label).Text);
                    nr++;
                    if (nr > this.stock)
                        (c as Label).Text = this.stock.ToString();
                    else
                        (c as Label).Text = nr.ToString();
                }
            }
        }




        public void layoutImagine(PictureBox imagine)
        {
            imagine.Location = new Point(0, 0);
            imagine.Size = new Size(200, 150);
            Image im = Image.FromFile(Application.StartupPath +@"\images\"+this.image+".png");
            imagine.Cursor = Cursors.Hand;
            imagine.BackgroundImage = im;
            imagine.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void layoutDescriere(Label descriere)
        {
            descriere.AutoSize = false;
            descriere.Location = new Point(200, 0);
            descriere.Size = new Size(435, 50);
            descriere.Font = new Font("Cambria", 18, FontStyle.Regular);
            descriere.BackColor = SystemColors.ControlLightLight;
            descriere.Text = this.name + " " + this.numeTelefon;
            descriere.TextAlign = ContentAlignment.MiddleLeft;
            descriere.Cursor = Cursors.Hand;
        }

        public void layoutStergere(Label stergere)
        {
            stergere.AutoSize = false;
            stergere.Location = new Point(425, 110);
            stergere.Size = new Size(150, 30);
            stergere.Font = new Font("Cambria", 14, FontStyle.Regular);
            stergere.BackColor = SystemColors.ControlLightLight;
            stergere.Text = "Stergere";
            stergere.Name = "stergere";
            stergere.ForeColor = Color.Red;
            stergere.TextAlign = ContentAlignment.MiddleLeft;
            stergere.Cursor = Cursors.Hand;
            stergere.Click += new EventHandler(stergere_Click);
        }

        public void stergere_Click(object sender, EventArgs e)
        {
            this.Hide();
        }



        public void layoutOldPrice(Label oldPrice)
        {
            oldPrice.AutoSize = false;
            oldPrice.Location = new Point(205, 70);
            oldPrice.Size = new Size(120, 20);
            oldPrice.Font = new Font("Cambria", 14, FontStyle.Regular | FontStyle.Strikeout | FontStyle.Italic);
            oldPrice.BackColor = SystemColors.ControlLightLight;
            oldPrice.ForeColor = Color.Gray;
            oldPrice.Text = ((double)((3 * this.price) / 10 + this.price)).ToString() + " Lei";
            oldPrice.TextAlign = ContentAlignment.MiddleLeft;
            oldPrice.Cursor = Cursors.Hand;
        }

        public void layoutPrice(Label price)
        {
            price.AutoSize = false;
            price.Location = new Point(200, 100);
            price.Size = new Size(120, 50);
            price.Font = new Font("Cambria", 18, FontStyle.Regular | FontStyle.Bold);
            price.BackColor = SystemColors.ControlLightLight;
            price.ForeColor = Color.Red;
            price.Text = this.price.ToString() + " Lei";
            price.TextAlign = ContentAlignment.TopLeft;
            price.Cursor = Cursors.Hand;
        }



    }
}
