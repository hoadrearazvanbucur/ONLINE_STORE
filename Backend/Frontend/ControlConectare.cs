using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Backend.Class;
using Backend.Controller;

namespace Frontend
{
    public class ControlConectare
    {
        private Form forma;
        private Customer customer;
        private Order order;
        private ControlCustomer controlCustomer;
        private ControlOrder controlOrder;
        private Panel header;
        private Panel footer;

        public ControlConectare(Form forma)
        {
            this.forma = forma;
            this.controlCustomer = new ControlCustomer();
            controlCustomer.load();
            this.controlOrder = new ControlOrder();
            controlOrder.load();
            this.header = new Panel();
            this.footer = new Panel();
            start();
        }

        public void start()
        {
            layoutPanel();
            layoutFooter();
            titlul();
            creare();

        }

        public void creare()
        {
            Label t = new Label();
            t.Text = "Creati un cont!";
            t.Font = new Font("Calibri", 12, FontStyle.Bold);
            t.Location = new Point(115, 170);
            t.Size = new Size(150, 30);
            t.TextAlign = ContentAlignment.MiddleCenter;
            t.Click += new EventHandler(t_Click);
            this.footer.Controls.Add(t);
        }

        public void t_Click(object sender, EventArgs e)
        {
            footer.Controls.Clear();
            Panel usernameP = new Panel();
            TextBox usernameT = new TextBox();
            usernameT.Name = "u";
            Label usernameL = new Label();
            OpUsernameC(usernameP, usernameT, usernameL);
            this.footer.Controls.Add(usernameP);
            this.footer.Controls.Add(usernameT);
            this.footer.Controls.Add(usernameL);

            Panel passwordP = new Panel();
            TextBox passwordT = new TextBox();
            Label passwordL = new Label();
            passwordT.Name = "p";
            OpPasswordC(passwordP, passwordT, passwordL);
            this.footer.Controls.Add(passwordP);
            this.footer.Controls.Add(passwordT);
            this.footer.Controls.Add(passwordL);

            Button trimitere = new Button();
            BtnTrimitereC(trimitere);
            this.footer.Controls.Add(trimitere);
        }

        public void BtnTrimitereC(Button trimitere)
        {
            trimitere.Text = "Creare";
            trimitere.Font = new Font("Calibri", 12, FontStyle.Bold);
            trimitere.Location = new Point(0, 330);
            trimitere.Size = new Size(this.footer.Width, 50);
            trimitere.Click += new EventHandler(trimitereC_Click);
        }
        public void layoutForm()
        {
            this.forma.Name = "form";
            this.forma.Size = new Size(1200, 700);
            this.forma.MaximumSize = new Size(1200, 700);
            this.forma.MinimumSize = new Size(1200, 700);
            this.forma.StartPosition = FormStartPosition.Manual;
            this.forma.Left = Screen.PrimaryScreen.Bounds.Width/2-600;
            this.forma.Top = Screen.PrimaryScreen.Bounds.Height/2-350;
            this.forma.FormBorderStyle = FormBorderStyle.None;
            this.forma.BackColor = SystemColors.ControlLightLight;
        }

        public void OpUsernameC(Panel uP, TextBox uT, Label uL)
        {
            uP.BorderStyle = BorderStyle.FixedSingle;
            uP.Size = new Size(this.footer.Width - 60, 1);
            uP.Location = new Point(30, 70);

            uT.BorderStyle = BorderStyle.None;
            uT.Font = new Font("Calibri", 12, FontStyle.Bold);
            uT.Location = new Point(30, 50);
            uT.Size = new Size(this.footer.Width - 60, 30);
            uT.MaxLength = 30;
            uT.TextAlign = HorizontalAlignment.Center;

            uL.Font = new Font("Calibri", 15, FontStyle.Bold);
            uL.Text = "Noul Username";
            uL.Location = new Point(50, 15);
            uL.Size = new Size(150, 30);
        }

        public void OpPasswordC(Panel pP, TextBox pT, Label pL)
        {
            pP.BorderStyle = BorderStyle.FixedSingle;
            pP.Size = new Size(this.footer.Width - 60, 1);
            pP.Location = new Point(30, 160);

            pT.BorderStyle = BorderStyle.None;
            pT.Font = new Font("Calibri", 12, FontStyle.Bold);
            pT.Location = new Point(30, 140);
            pT.Size = new Size(this.footer.Width - 60, 30);
            pT.MaxLength = 30;
            pT.TextAlign = HorizontalAlignment.Center;

            pL.Font = new Font("Calibri", 15, FontStyle.Bold);
            pL.Text = "Noul Password";
            pL.Location = new Point(50, 105);
            pL.Size = new Size(150, 30);
        }

        public void titlul()
        {
            Label t = new Label();
            t.Text = "Magazin Online";
            t.Font = new Font("Calibri", 20, FontStyle.Bold);
            t.Location = new Point(0, 30);
            t.Size = new Size(this.header.Width, this.header.Height-30);
            t.TextAlign = ContentAlignment.MiddleCenter;
            this.header.Controls.Add(t);


            PictureBox exitPicture = new PictureBox();
            layoutExitPicture(exitPicture);
            this.header.Controls.Add(exitPicture);
        }

        public void layoutPanel()
        {
            this.header.Location = new Point(0, 0);
            this.footer.Location = new Point(0, this.forma.Height / 5);

            this.header.Size = new Size(this.forma.Width, this.forma.Height / 5);
            this.footer.Size = new Size(this.forma.Width, this.forma.Height - this.forma.Height / 5);

            this.forma.Controls.Add(this.header);
            this.forma.Controls.Add(this.footer);
        }

        public void layoutFooter()
        {
            Panel usernameP = new Panel();
            TextBox usernameT = new TextBox();
            usernameT.Name = "u";
            Label usernameL = new Label();
            OpUsername(usernameP, usernameT, usernameL);
            this.footer.Controls.Add(usernameP);
            this.footer.Controls.Add(usernameT);
            this.footer.Controls.Add(usernameL);

            Panel passwordP = new Panel();
            TextBox passwordT = new TextBox();
            Label passwordL = new Label();
            passwordT.Name = "p";
            OpPassword(passwordP, passwordT, passwordL);
            this.footer.Controls.Add(passwordP);
            this.footer.Controls.Add(passwordT);
            this.footer.Controls.Add(passwordL);

            Button trimitere = new Button();
            BtnTrimitere(trimitere);
            this.footer.Controls.Add(trimitere);
        }

        public void layoutExitPicture(PictureBox exitPicture)
        {
            exitPicture.Location = new Point(this.header.Width-30, 10);
            exitPicture.Size = new Size(20, 20);
            Image im = Image.FromFile(Application.StartupPath + @"\images\close.png");
            exitPicture.BackgroundImage = im;
            exitPicture.BackgroundImageLayout = ImageLayout.Stretch;
            exitPicture.Cursor = Cursors.Hand;
            exitPicture.Click += new EventHandler(exit_Click);
        }
        public void exit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.forma.Controls.Clear();
            this.header.Controls.Clear();
            this.footer.Controls.Clear();
            start();
        }




        public void BtnTrimitere(Button trimitere)
        {
            trimitere.Text = "Conectare";
            trimitere.Font = new Font("Calibri", 12, FontStyle.Bold);
            trimitere.Location = new Point(0, 330);
            trimitere.Size = new Size(this.footer.Width, 50);
            trimitere.Click += new EventHandler(trimitere_Click);
        }

        public void OpUsername(Panel uP, TextBox uT, Label uL)
        {
            uP.BorderStyle = BorderStyle.FixedSingle;
            uP.Size = new Size(this.footer.Width - 60, 1);
            uP.Location = new Point(30, 70);

            uT.BorderStyle = BorderStyle.None;
            uT.Font = new Font("Calibri", 12, FontStyle.Bold);
            uT.Location = new Point(30, 50);
            uT.Size = new Size(this.footer.Width - 60, 30);
            uT.MaxLength = 30;
            uT.TextAlign = HorizontalAlignment.Center;

            uL.Font = new Font("Calibri", 15, FontStyle.Bold);
            uL.Text = "Username";
            uL.Location = new Point(50, 15);
            uL.Size = new Size(150, 30);
        }

        public void OpPassword(Panel pP, TextBox pT, Label pL)
        {
            pP.BorderStyle = BorderStyle.FixedSingle;
            pP.Size = new Size(this.footer.Width - 60, 1);
            pP.Location = new Point(30, 160);

            pT.BorderStyle = BorderStyle.None;
            pT.Font = new Font("Calibri", 12, FontStyle.Bold);
            pT.Location = new Point(30, 140);
            pT.Size = new Size(this.footer.Width - 60, 30);
            pT.MaxLength = 30;
            pT.TextAlign = HorizontalAlignment.Center;

            pL.Font = new Font("Calibri", 15, FontStyle.Bold);
            pL.Text = "Password";
            pL.Location = new Point(50, 105);
            pL.Size = new Size(150, 30);
        }


        public void trimitere_Click(object sender, EventArgs e)
        {
            TextBox u = null;
            TextBox p = null;
            foreach (Control c in this.footer.Controls)
            {
                if (c.Name == "u")
                    u = c as TextBox;
                else
                    if (c.Name == "p")
                    p = c as TextBox;
            }
            if (u.Text != "" && p.Text != "" && controlCustomer.accVerification(u.Text, p.Text))
            {
                Customer customer = controlCustomer.customerAcc(u.Text, p.Text);
                //Order order = controlOrder.orderAcc(customer.Id);
                Order order = new Order(new string[] { $"{controlOrder.nextId()}", $"{customer.Id}", "0", "Rasinari" });

                //MessageBox.Show(customer.afisare() + "\n\n\n" + order.afisare());
                layoutForm();
                this.forma.Controls.Clear();
                ControlHeader header = new ControlHeader(this.forma, order, customer);
                header.Location = new Point(13, 13);
                this.forma.Controls.Add(header);

                ControlButtonsBar bar = new ControlButtonsBar(this.forma, order, customer);
                bar.Location = new Point(0, 109);
                this.forma.Controls.Add(bar);

                ControlMain main = new ControlMain(order, customer, this.forma, 1, "");
                main.Name = "main";
                main.Location = new Point(13, 145);
                this.forma.Controls.Add(main);
            }
            else
                MessageBox.Show("Contul nu exista!");
        }



        public void trimitereC_Click(object sender, EventArgs e)
        {
            TextBox u = null;
            TextBox p = null;
            foreach (Control c in this.footer.Controls)
            {
                if (c.Name == "u")
                    u = c as TextBox;
                else
                    if (c.Name == "p")
                    p = c as TextBox;
            }
            if (u.Text != "" && p.Text != "" && !controlCustomer.accVerification(u.Text, p.Text))
            {
                Customer customer = new Customer(new string[] { "email", $"{p.Text}", $"{u.Text}", $"{controlCustomer.nextId()}" });
                Order order = new Order(new string[] { $"{controlOrder.nextId()}", $"{customer.Id}", "0", "Rasinari" });
                controlCustomer.adaugare(customer);
                controlCustomer.save();
                MessageBox.Show(customer.afisare() + "\n\n\n" + order.afisare());
                layoutForm();
                this.forma.Controls.Clear();
                ControlHeader header = new ControlHeader(this.forma, order, customer);
                header.Location = new Point(13, 13);
                this.forma.Controls.Add(header);

                ControlButtonsBar bar = new ControlButtonsBar(this.forma, order, customer);
                bar.Location = new Point(0, 109);
                this.forma.Controls.Add(bar);

                ControlMain main = new ControlMain(order, customer, this.forma, 1, "");
                main.Name = "main";
                main.Location = new Point(13, 145);
                this.forma.Controls.Add(main);
            }
            else
                MessageBox.Show("Contul nu poate fi creat sau exista deja!");
        }
    }
}
