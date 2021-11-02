using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Frontend
{
    public class ControlSumar : Panel
    {
        private int price;
        public ControlSumar(int price)
        {
            this.price = price;
            layoutPanel();
            layouts();
        }

        public void layoutPanel()
        {
            this.Size = new Size(250, 300);
            this.BackColor = SystemColors.ControlLightLight;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void layouts()
        {
            Label sumarA = new Label();
            layoutSumarA(sumarA);
            this.Controls.Add(sumarA);

            Label totalA = new Label();
            layoutTotalA(totalA);
            this.Controls.Add(totalA);

            Label subtotal = new Label();
            layoutSubtotal(subtotal);
            this.Controls.Add(subtotal);

            Label livrare = new Label();
            layoutLivrare(livrare);
            this.Controls.Add(livrare);

            Label totalP = new Label();
            layoutTotalP(totalP);
            this.Controls.Add(totalP);

            Button comanda = new Button();
            layoutComanda(comanda);
            this.Controls.Add(comanda);
        }

        public void layoutSumarA(Label sumarA)
        {
            sumarA.AutoSize = false;
            sumarA.Location = new Point(0, 0);
            sumarA.Size = new Size(250, 40);
            sumarA.Font = new Font("Cambria", 18, FontStyle.Regular);
            sumarA.BackColor = SystemColors.ControlLightLight;
            sumarA.TextAlign = ContentAlignment.MiddleCenter;
            sumarA.Text = "Sumar comanda";
        }

        public void layoutTotalA(Label totalA)
        {
            totalA.AutoSize = false;
            totalA.Location = new Point(0, 50);
            totalA.Size = new Size(250, 20);
            totalA.Font = new Font("Cambria", 14, FontStyle.Regular);
            totalA.BackColor = SystemColors.ControlLightLight;
            totalA.TextAlign = ContentAlignment.MiddleCenter;
            totalA.Text = "Subtotal:                  " + this.price + " Lei";
        }

        public void layoutSubtotal(Label subtotal)
        {
            subtotal.AutoSize = false;
            subtotal.Location = new Point(0, 80);
            subtotal.Size = new Size(250, 20);
            subtotal.Font = new Font("Cambria", 14, FontStyle.Regular);
            subtotal.BackColor = SystemColors.ControlLightLight;
            subtotal.TextAlign = ContentAlignment.MiddleCenter;
            subtotal.Text = "Taxa de livrare:          15 Lei";
        }


        public void layoutLivrare(Label livrare)
        {
            livrare.AutoSize = false;
            livrare.Location = new Point(0, 120);
            livrare.Size = new Size(250, 40);
            livrare.Font = new Font("Cambria", 18, FontStyle.Regular);
            livrare.BackColor = SystemColors.ControlLightLight;
            livrare.TextAlign = ContentAlignment.MiddleCenter;
            livrare.Text = "Total plata";
        }

        public void layoutTotalP(Label totalP)
        {
            totalP.AutoSize = false;
            totalP.Location = new Point(0, 160);
            totalP.Size = new Size(250, 20);
            totalP.Font = new Font("Cambria", 14, FontStyle.Regular);
            totalP.BackColor = SystemColors.ControlLightLight;
            totalP.TextAlign = ContentAlignment.MiddleCenter;
            totalP.Text = (this.price + 15).ToString() + " Lei";
        }

        public void layoutComanda(Button comanda)
        {
            comanda.Text = "Comanda";
            comanda.Font = new Font("Cambria", 16, FontStyle.Bold);
            comanda.BackColor = Color.Transparent;
            comanda.Location = new Point(25, 240);
            comanda.Size = new Size(200, 50);
            comanda.BackColor = Color.Brown;
            comanda.Cursor = Cursors.Hand;
            comanda.Click += comanda_Click;
        }

        public void comanda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Comanda");
        }
    }
}
