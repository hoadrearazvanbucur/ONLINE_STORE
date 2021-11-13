using Backend.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Backend.Controller
{
    public class ControlOrder
    {
        private List<Order> orders;

        public ControlOrder()
        {
            orders = new List<Order>();
            load();
        }


        public void load()
        {
            this.orders.Clear();
            string path = @"D:\1_PROGRAMARE\C#\ONLINE_STORE\Backend\Backend\Controller\Resources\orderFile.txt";
            StreamReader fisier = new StreamReader(path);
            string linie = "";
            while ((linie = fisier.ReadLine()) != null){
                string[] linieSplit = linie.Split(',');
                orders.Add(new Order(linieSplit));
            }
            fisier.Close();
        }
        public void save()
        {
            string path = @"D:\1_PROGRAMARE\C#\ONLINE_STORE\Backend\Backend\Controller\Resources\orderFile.txt";
            StreamWriter fisier = new StreamWriter(path);
            foreach (Order order in orders)
                fisier.WriteLine(order.ToString());
            fisier.Close();
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
        }
        public void stergere(int id)
        {
            this.orders.RemoveAt(orderId(id));
        }


        public void updateOrderAdress(int id, string orderAdressNou)
        {
            orders[orderId(id)].Order_Address = orderAdressNou;
        }
        public void updateAmmount(int id, int ammountNou)
        {
            orders[orderId(id)].Ammount = ammountNou;
        }


        public int orderId(int id)
        {
            int k = 0;
            foreach (Order order in orders)
                if (order.Id == id) return k;
                else k++;
            return -1;
        }
        public Order orderObjectId(int id)
        {
            foreach (Order order in orders)
                if (order.Id.Equals(id) == true)
                    return order;
            return null;
        }
        public List<Order> Order
        {
            get => this.orders;
            set => this.orders = value;
        }
        public Order orderAcc(int customer_id)
        {
            foreach (Order o in this.orders)
                if (o.Custormer_id.Equals(customer_id) == true)
                    return o;
            return null;
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
