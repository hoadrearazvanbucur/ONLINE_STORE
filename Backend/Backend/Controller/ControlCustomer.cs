using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Controller
{
    public class ControlCustomer
    {
        private List<Order> orders;

        public ControlOrder()
        {
            orders = new List<Order>();
            load();
        }


        public void load()
        {
            string path = @"D:\1_PROGRAMARE\C#\ONLINE_STORE\TEST.txt";
            StreamReader fisier = new StreamReader(path);
            string linie = "";
            while ((linie = fisier.ReadLine()) != null)
            {
                string[] linieSplit = linie.Split(',');
                orders.Add(new Order(linieSplit));
            }
            fisier.Close();
        }
        public void save()
        {
            string path = @"D:\1_PROGRAMARE\C#\ONLINE_STORE\TEST.txt";
            StreamWriter fisier = new StreamWriter(path);
            fisier.WriteLine(this.ToString());
            fisier.Close();
        }


        public override string ToString()
        {
            string text = "";
            foreach (Order order in orders)
            {
                text += order + "\n";
            }
            return text;
        }


        public string afisare()
        {
            string afis = "";
            foreach (Order order in orders)
                afis += order.afisare();
            return afis;
        }

        public void adaugare(Order order)
        {
            orders.Add(order);
            save();
        }

        public void stergere(int id)
        {
            this.orders.RemoveAt(productId(id));
            save();
        }


        //Product
        public void updateName(int id, string numeNou)
        {
            orders[productId(id)].Order_Address = numeNou;//a
        }




        public int productId(int id)
        {
            int k = 0;
            foreach (Order order in orders)
                if (order.Id == id) return k;
                else k++;
            return -1;
        }


        public List<Order> Order
        {
            get => this.orders;
            set => this.orders = value;
        }


        public int nextId()
        {
            if (this.orders.Count > 0)
                return this.orders[this.orders.Count - 1].Id + 1;
            else
                return 1;
        }
    }
}
