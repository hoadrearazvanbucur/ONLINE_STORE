using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Backend.Class;

namespace Frontend
{
    public class ControlHeader : Panel
    {
        private Form form;
        private Order order;
        private Customer customer;

        public ControlHeader(Form form,Order order,Customer customer)
        {
            this.order = order;
            this.form = form;
            this.customer = customer;
            layoutPanel();
            layouts();
        }

        public void layoutPanel()
        {
            this.Size = new Size(1175, 90);
            this.BackColor = SystemColors.ControlLightLight;
            this.BorderStyle = BorderStyle.None;
        }

        public void layouts()
        {
            PictureBox logo = new PictureBox();
            layoutLogo(logo);
            this.Controls.Add(logo);

            PictureBox userPicture = new PictureBox();
            layoutUserPicture(userPicture);
            this.Controls.Add(userPicture);

            PictureBox cartPicture = new PictureBox();
            layoutCartPicture(cartPicture);
            this.Controls.Add(cartPicture);

            Label userLabel = new Label();
            layoutUserLabel(userLabel);
            this.Controls.Add(userLabel);

            Label cartLabel = new Label();
            layoutCartLabel(cartLabel);
            this.Controls.Add(cartLabel);

            Panel search = new Panel();
            layoutSearch(search);
            search.Name = "search";
            this.Controls.Add(search);

            TextBox searchText = new TextBox();
            layoutSearchText(searchText);
            searchText.Name = "text";
            search.Controls.Add(searchText);

            PictureBox searchPicture = new PictureBox();
            layoutSearchPicture(searchPicture);
            search.Controls.Add(searchPicture);

            PictureBox exitPicture = new PictureBox();
            layoutExitPicture(exitPicture);
            this.Controls.Add(exitPicture);
        }

        public void layoutLogo(PictureBox logo)
        {
            logo.Location = new Point(77, 16);
            logo.Size = new Size(148, 52);
            Image im = Image.FromFile(Application.StartupPath + @"\images\logo.png");
            logo.Cursor = Cursors.Hand;
            logo.BackgroundImage = im;
            logo.BackgroundImageLayout = ImageLayout.Stretch;
            logo.Click += new EventHandler(logo_Click);
        }
        public void logo_Click(object sender, EventArgs e)
        {
            Panel cos = null;
            foreach (Control control in this.form.Controls)
            {
                if (control is Panel && (control.Name.Equals("cos") == true|| control.Name.Equals("main") == true))
                    cos = control as Panel;
            }
            form.Controls.Remove(cos);

            ControlMain main = new ControlMain(order, customer, this.form,1, "");
            main.Name = "main";
            main.Location = new Point(13, 145);
            this.form.Controls.Add(main);
        }


        public void layoutUserPicture(PictureBox userPicture)
        {
            userPicture.Location = new Point(861, 25);
            userPicture.Size = new Size(34, 30);
            Image im = Image.FromFile(Application.StartupPath + @"\images\user.png");
            userPicture.Cursor = Cursors.Hand;
            userPicture.BackgroundImage = im;
            userPicture.BackgroundImageLayout = ImageLayout.Stretch;
            userPicture.Click += new EventHandler(userPicture_Click);
        }
        public void layoutUserLabel(Label userLabel)
        {
            userLabel.AutoSize = false;
            userLabel.Location = new Point(895, 25);
            userLabel.Size = new Size(100, 30);
            userLabel.Cursor = Cursors.Hand;
            userLabel.Click += new EventHandler(userPicture_Click);
            userLabel.Font = new Font("Cambria", 13, FontStyle.Regular);
            userLabel.BackColor = SystemColors.ControlLightLight;
            userLabel.Text = customer.FullName;
            userLabel.TextAlign = ContentAlignment.MiddleLeft;
        }
        public void userPicture_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Cont");
        }


        public void layoutCartPicture(PictureBox cartPicture)
        {
            cartPicture.Location = new Point(991, 25);
            cartPicture.Size = new Size(34, 30);
            Image im = Image.FromFile(Application.StartupPath + @"\images\shopping_cart.png");
            cartPicture.Cursor = Cursors.Hand;
            cartPicture.BackgroundImage = im;
            cartPicture.BackgroundImageLayout = ImageLayout.Stretch;
            cartPicture.Click += new EventHandler(cartPicture_Click);
        }
        public void layoutCartLabel(Label cartLabel)
        {
            cartLabel.AutoSize = false;
            cartLabel.Location = new Point(1025, 25);
            cartLabel.Size = new Size(100, 30);
            cartLabel.Cursor = Cursors.Hand;
            cartLabel.Click += new EventHandler(cartPicture_Click);
            cartLabel.Font = new Font("Cambria", 13, FontStyle.Regular);
            cartLabel.BackColor = SystemColors.ControlLightLight;
            cartLabel.Text = "Cosul meu";
            cartLabel.TextAlign = ContentAlignment.MiddleLeft;
        }
        public void cartPicture_Click(object sender, EventArgs e)
        {
            Panel main = null;
            foreach(Control control in this.form.Controls)
            {
                if (control is Panel && control.Name.Equals("main") == true)
                    main = control as Panel;              
            }
            form.Controls.Remove(main);

            ControlCos cos = new ControlCos(this.order,this.form,this.customer);
            cos.Name = "cos";
            cos.Location = new Point(13, 145);
            this.form.Controls.Add(cos);
        }


        public void layoutSearch(Panel search)
        {
            search.Size = new Size(480, 52);
            search.Location = new Point(231, 16);
            search.BackColor = SystemColors.ControlLightLight;
            search.BorderStyle = BorderStyle.FixedSingle;
        }
        public void layoutSearchPicture(PictureBox searchPicture)
        {
            searchPicture.Location = new Point(433, 8);
            searchPicture.Size = new Size(34, 30);
            Image im = Image.FromFile(Application.StartupPath + @"\images\loupe.png");
            searchPicture.BackgroundImage = im;
            searchPicture.Cursor = Cursors.Hand;
            searchPicture.BackgroundImageLayout = ImageLayout.Stretch;
            searchPicture.Click += new EventHandler(search_Click);
        }
        public void layoutSearchText(TextBox searchText)
        {
            searchText.Font = new Font("Cambria", 14, FontStyle.Regular);
            searchText.ForeColor = SystemColors.WindowText;
            searchText.Text = "";
            searchText.Location = new Point(10, 13);
            searchText.Size = new Size(417, 23);
            searchText.BorderStyle = BorderStyle.None;
            searchText.BackColor = SystemColors.ControlLightLight;
            searchText.TextChanged += new EventHandler(search_TextChanged);
        }
        public void search_TextChanged(object sender, EventArgs e)
        {

        }
        public void search_Click(object sender, EventArgs e)
        {
            Panel cos = null;
            Panel search = null;
            foreach (Control control in this.form.Controls)
            {
                if (control is Panel && (control.Name.Equals("cos") == true || control.Name.Equals("main") == true))
                    cos = control as Panel;
            }
            foreach (Control control in this.Controls)
                if (control is Panel && (control as Panel).Name.Equals("search") == true)
                    search = control as Panel;

            TextBox textBox = null;
            foreach (Control control in search.Controls)
                if (control is TextBox && control.Name.Equals("text") == true)
                    textBox = control as TextBox;

            form.Controls.Remove(cos);
            ControlMain main = new ControlMain(order, customer, this.form, 5, textBox.Text);
            main.Name = "main";
            main.Location = new Point(13, 145);
            this.form.Controls.Add(main);
        }


        public void layoutExitPicture(PictureBox exitPicture)
        {
            exitPicture.Location = new Point(1152, 0);
            exitPicture.Size = new Size(20, 20);
            Image im = Image.FromFile(Application.StartupPath + @"\images\close.png");
            exitPicture.BackgroundImage = im;
            exitPicture.BackgroundImageLayout = ImageLayout.Stretch;
            exitPicture.Cursor = Cursors.Hand;
            exitPicture.Click += new EventHandler(exit_Click);
        }
        public void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
