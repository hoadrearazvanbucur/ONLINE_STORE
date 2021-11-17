using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Backend.Controller;
using Backend.Class;
using Backend.Model.Products;
using Backend.ControlClass;

namespace Frontend
{
    public class ControlMain : Panel
    {
        private ControlProduct controlProducts;
        private ControlOrder controlOrder;
        private ControlOrderDetail controlOrderDetail;
        private ControlCustomer controlCustomer;

        private Customer customer;
        private Order order;
        private Form form;

        private int timer;
        private PictureBox reclame;

        private int buttonsBar;
        private string search;

        public ControlMain(Order order, Customer customer, Form form, int buttonsBar, string search)
        {
            this.form = form;

            this.timer = 0;
            this.reclame = new PictureBox();

            this.controlProducts = new ControlProduct();
            this.controlOrder = new ControlOrder();
            this.controlOrderDetail = new ControlOrderDetail();
            this.controlCustomer = new ControlCustomer();

            this.customer = customer;
            this.order = order;

            this.buttonsBar = buttonsBar;
            this.search = search;

            timerCreate();
            layoutPanel();
            layouts();
            comboSortare();
            comboFiltrare();
            if (this.buttonsBar == 1)
                layoutProduse();
            if (this.buttonsBar == 2)
                layoutPromotii();
            if (this.buttonsBar == 3)
                layoutBranduri();
            if (this.buttonsBar == 4)
                layoutSuportClienti();
            if (this.buttonsBar == 5)
                layoutSearch();
            if (this.buttonsBar == 6)
                layoutIstoricComenzi();
            if (this.buttonsBar == 7)
                sortare(1);
            if (this.buttonsBar == 8)
                filtrare(1, "Apple");



            Label TEST = new Label();
            TEST.Location = new Point(10, 2000);
            this.Controls.Add(TEST);
        }

        public void timerCreate()
        {
            Timer t = new Timer();
            t.Interval = 5000;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();
        }
        public void layoutReclame()
        {
            this.reclame.Location = new Point(0, 0);
            this.reclame.Size = new Size(1000, 250);
            Image im = null;
            if (this.timer == 0) im = Image.FromFile(Application.StartupPath + @"\images\reclama1.png");
            if (this.timer == 1) im = Image.FromFile(Application.StartupPath + @"\images\reclama2.png");
            if (this.timer == 2) im = Image.FromFile(Application.StartupPath + @"\images\reclama3.png");
            this.reclame.BackgroundImage = im;
            this.reclame.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            if (this.timer == 2)
                this.timer = 0;
            else
                this.timer++;
            layoutReclame();
        }
        public void layoutReclameP(Panel reclameP)
        {
            reclameP.Location = new Point(77, 0);
            reclameP.Size = new Size(1000, 250);
            reclameP.BackColor = SystemColors.ControlLightLight;
            reclameP.BorderStyle = BorderStyle.FixedSingle;
        }



        public void layoutPanel()
        {
            this.Size = new Size(1175, 543);
            this.BackColor = SystemColors.ControlLightLight;
            this.BorderStyle = BorderStyle.None;
            this.AutoScroll = true;
        }
        public void layouts()
        {
            Panel reclameP = new Panel();
            layoutReclameP(reclameP);
            this.Controls.Add(reclameP);
            reclameP.Controls.Add(reclame);

            layoutReclame();

            Label oferte = new Label();
            layoutOferte(oferte);
            this.Controls.Add(oferte);
        }



        public void layoutProduse()
        {
            List<Product> lista = controlProducts.afisareCard;
            int k1 = 1, k2 = 0;

            foreach (Product produs in lista)
            {
                ControlCard card = new ControlCard(produs.Id, produs.Name, produs.Image, produs.Price, produs.Stock, (produs as Phone).PhoneName);
                if (k2 > 900)
                {
                    k2 = 0;
                    k1 += 450;
                }
                card.Location = new Point(75 + k2, 420 + k1);

                Button b = null;
                foreach (Control controale in card.Controls)
                    if (controale is Button)
                    {
                        Button cos = controale as Button;
                        if (cos.Name.Contains("cos") == true)
                            b = cos;
                    }
                b.Click += addCos_Click;
                k2 += 267;
                this.Controls.Add(card);
            }
        }
        public void layoutPromotii()
        {
            List<Product> lista = controlProducts.afisareCard;
            int k1 = 1, k2 = 0;

            foreach (Product produs in lista)
            {
                if (produs.Price <= 5300)
                {
                    ControlCard card = new ControlCard(produs.Id, produs.Name, produs.Image, produs.Price, produs.Stock, (produs as Phone).PhoneName);
                    if (k2 > 900)
                    {
                        k2 = 0;
                        k1 += 450;
                    }
                    card.Location = new Point(75 + k2, 420 + k1);

                    Button b = null;
                    foreach (Control controale in card.Controls)
                        if (controale is Button)
                        {
                            Button cos = controale as Button;
                            if (cos.Name.Contains("cos") == true)
                                b = cos;
                        }
                    b.Click += addCos_Click;
                    k2 += 267;
                    this.Controls.Add(card);
                }
            }
        }
        public void layoutBranduri()
        {
            Label iphone = new Label();
            iphone.AutoSize = false;
            iphone.Location = new Point(300, 400);
            iphone.Size = new Size(200, 50);
            iphone.Cursor = Cursors.Hand;
            iphone.Font = new Font("Cambria", 25, FontStyle.Regular);
            iphone.BackColor = SystemColors.ControlLightLight;
            iphone.Text = "Apple";
            iphone.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(iphone);
            Label samsung = new Label();
            samsung.AutoSize = false;
            samsung.Location = new Point(650, 400);
            samsung.Size = new Size(200, 50);
            samsung.Cursor = Cursors.Hand;
            samsung.Font = new Font("Cambria", 25, FontStyle.Regular);
            samsung.BackColor = SystemColors.ControlLightLight;
            samsung.Text = "Samsung";
            samsung.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(samsung);
        }
        public void layoutSuportClienti()
        {
            Label iphone = new Label();
            iphone.AutoSize = false;
            iphone.Location = new Point(300, 400);
            iphone.Size = new Size(1000, 100);
            iphone.Cursor = Cursors.Hand;
            iphone.Font = new Font("Cambria", 13, FontStyle.Regular);
            iphone.BackColor = SystemColors.ControlLightLight;
            iphone.Text = "Contacteaza-ne la urmatorul numar de telefon daca intampinati probleme:\n                                                            0712345678";
            iphone.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(iphone);
        }
        public void layoutSearch()
        {
            List<Product> lista = controlProducts.afisareCard;
            int k1 = 1, k2 = 0;

            foreach (Product produs in lista)
            {
                if (produs.Name == this.search)
                {
                    ControlCard card = new ControlCard(produs.Id, produs.Name, produs.Image, produs.Price, produs.Stock, (produs as Phone).PhoneName);
                    if (k2 > 900)
                    {
                        k2 = 0;
                        k1 += 450;
                    }
                    card.Location = new Point(75 + k2, 420 + k1);

                    Button b = null;
                    foreach (Control controale in card.Controls)
                        if (controale is Button)
                        {
                            Button cos = controale as Button;
                            if (cos.Name.Contains("cos") == true)
                                b = cos;
                        }
                    b.Click += addCos_Click;
                    k2 += 267;
                    this.Controls.Add(card);
                }
            }
        }
        public void layoutIstoricComenzi()
        {
            Label[] istoric = new Label[100];
            int i = 0;
            foreach (OrderDetail orderDetail in controlOrderDetail.OrderDetail)
            {
                istoric[i] = new Label();
                istoric[i].AutoSize = false;
                istoric[i].Location = new Point(530, 300 * (i + 1));
                istoric[i].Size = new Size(300, 300);
                istoric[i].Cursor = Cursors.Hand;
                istoric[i].Font = new Font("Cambria", 13, FontStyle.Regular);
                istoric[i].BackColor = SystemColors.ControlLightLight;
                istoric[i].Text = orderDetail.afisare();
                istoric[i].TextAlign = ContentAlignment.MiddleLeft;
                this.Controls.Add(istoric[i]);
                i++;
            }
        }
        public void addCos_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            MessageBox.Show("Produs adaugat cu Succes!");
            int id = int.Parse(button.Name.Split(",")[1]);
            OrderDetail orderDetail = new OrderDetail(new string[] { $"{controlOrderDetail.nextId()}", $"{this.order.Id}", $"{id}", "1", $"{this.controlProducts.productObjectID(id).Price}" });
            this.controlOrderDetail.adaugare(orderDetail);
            this.controlOrderDetail.save();
            this.controlOrderDetail.load();


        }


        public void layoutOferte(Label oferte)
        {
            oferte.AutoSize = false;
            oferte.Location = new Point(15, 288);
            oferte.Size = new Size(300, 30);
            oferte.Font = new Font("Cambria", 16, FontStyle.Regular);
            oferte.BackColor = SystemColors.ControlLightLight;
            if (this.buttonsBar == 1 || this.buttonsBar == 5)
                oferte.Text = "Ofertele zilei:";
            if (this.buttonsBar == 2)
                oferte.Text = "Promotiile zilei:";
            if (this.buttonsBar == 3)
                oferte.Text = "Branduri:";
            if (this.buttonsBar == 4)
                oferte.Text = "Suport Clienti:";
            if (this.buttonsBar == 6)
                oferte.Text = "Comenzile tale:";
        }


        public void sortare(int k)
        {
            comboSortare();
            comboFiltrare();
            List<Product> lista = new List<Product>();
            if (k == 1)
                lista = controlProducts.sortareNume(this.controlProducts.Products);
            if (k == 2)
                lista = controlProducts.sortarePrice(this.controlProducts.Products);
            if (k == 3)
                lista = controlProducts.sortareStock(this.controlProducts.Products);
            int k1 = 1, k2 = 0;

            foreach (Product produs in lista)
            {
                ControlCard card = new ControlCard(produs.Id, produs.Name, produs.Image, produs.Price, produs.Stock, (produs as Phone).PhoneName);
                if (k2 > 900)
                {
                    k2 = 0;
                    k1 += 450;
                }
                card.Location = new Point(75 + k2, 420 + k1);

                Button b = null;
                foreach (Control controale in card.Controls)
                    if (controale is Button)
                    {
                        Button cos = controale as Button;
                        if (cos.Name.Contains("cos") == true)
                            b = cos;
                    }
                b.Click += addCos_Click;
                k2 += 267;
                this.Controls.Add(card);
            }
        }
        public void filtrare(int k, string text)
        {
            comboSortare();
            comboFiltrare();
            List<Product> lista = new List<Product>();
            if (k == 1)
                lista = controlProducts.filtrareNume(this.controlProducts.Products, text);
            if (k == 2)
                lista = controlProducts.filtrarePrice(this.controlProducts.Products, int.Parse(text));
            if (k == 3)
                lista = controlProducts.filtrareStock(this.controlProducts.Products, int.Parse(text));
            int k1 = 1, k2 = 0;

            foreach (Product produs in lista)
            {
                ControlCard card = new ControlCard(produs.Id, produs.Name, produs.Image, produs.Price, produs.Stock, (produs as Phone).PhoneName);
                if (k2 > 900)
                {
                    k2 = 0;
                    k1 += 450;
                }
                card.Location = new Point(75 + k2, 420 + k1);

                Button b = null;
                foreach (Control controale in card.Controls)
                    if (controale is Button)
                    {
                        Button cos = controale as Button;
                        if (cos.Name.Contains("cos") == true)
                            b = cos;
                    }
                b.Click += addCos_Click;
                k2 += 267;
                this.Controls.Add(card);
            }
        }


        public void sortare_Click(object sender, EventArgs e)
        {
            this.form.Controls.Remove(this);
            ControlMain main1 = new ControlMain(order, customer, this.form, 7, "");
            main1.Name = "main";
            main1.Location = new Point(13, 145);
            this.form.Controls.Add(main1);
        }
        public void filtrare_Click(object sender,EventArgs e)
        {
            this.form.Controls.Remove(this);
            ControlMain main1 = new ControlMain(order, customer, this.form, 8, "");
            main1.Name = "main";
            main1.Location = new Point(13, 145);
            this.form.Controls.Add(main1);
        }

        public void comboSortare()  
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Location = new Point(945, 360);
            comboBox.Size = new Size(130, 40);
            comboBox.Text = "Sortare";
            comboBox.Items.Add("Nume");
            comboBox.Items.Add("Pret");
            comboBox.Items.Add("Stoc");

            Button sortare = new Button();
            sortare.AutoSize = false;
            sortare.Name = "";
            sortare.Location = new Point(800, 352);
            sortare.Size = new Size(100, 40);
            sortare.Font = new Font("Cambria", 10, FontStyle.Regular);
            sortare.BackColor = SystemColors.ControlLightLight;
            sortare.TextAlign = ContentAlignment.MiddleCenter;
            sortare.Text = "Sortare";
            this.Controls.Add(sortare);

            sortare.Click += new EventHandler(sortare_Click);
            this.Controls.Add(comboBox);
        }
        public void comboFiltrare()
        {
            Button filtrare = new Button();
            filtrare.AutoSize = false;
            filtrare.Name = "";
            filtrare.Location = new Point(75, 352);
            filtrare.Size = new Size(100, 40);
            filtrare.Font = new Font("Cambria", 12, FontStyle.Regular);
            filtrare.BackColor = SystemColors.ControlLightLight;
            filtrare.TextAlign = ContentAlignment.MiddleCenter;
            filtrare.Text = "Filtrare";
            filtrare.Click += new EventHandler(filtrare_Click);
            this.Controls.Add(filtrare);

            ComboBox comboBoxPret = new ComboBox();
            layoutComboBoxPret(comboBoxPret);
            this.Controls.Add(comboBoxPret);

            ComboBox comboBoxStock = new ComboBox();
            layoutComboBoxStock(comboBoxStock);
            this.Controls.Add(comboBoxStock);

            ComboBox comboBoxName = new ComboBox();
            layoutComboBoxName(comboBoxName);
            this.Controls.Add(comboBoxName);
        }

        public void layoutComboBoxPret(ComboBox comboBoxPret)
        {
            comboBoxPret.Location = new Point(180, 360);
            comboBoxPret.Size = new Size(130, 40);
            comboBoxPret.Text = "Pret";
            comboBoxPret.Items.Add("0-1000");
            comboBoxPret.Items.Add("1000-2000");
            comboBoxPret.Items.Add(">2000");
        }
        public void layoutComboBoxStock(ComboBox comboBoxStock)
        {
            comboBoxStock.Location = new Point(350, 360);
            comboBoxStock.Size = new Size(130, 40);
            comboBoxStock.Text = "Stoc";
            comboBoxStock.Items.Add("0-5");
            comboBoxStock.Items.Add("5-10");
            comboBoxStock.Items.Add(">10");
        }
        public void layoutComboBoxName(ComboBox comboBoxName)
        {
            comboBoxName.Location = new Point(450 + 70, 360);
            comboBoxName.Size = new Size(130, 40);
            comboBoxName.Text = "Nume";
            comboBoxName.Items.Add("Samsung");
            comboBoxName.Items.Add("Apple");
        }

    }
}
