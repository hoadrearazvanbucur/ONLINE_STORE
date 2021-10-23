using Backend.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Backend.Controller
{
    public class ControlOrderDetail
    {
        private List<OrderDetail> orderDetails;

        public ControlOrderDetail()
        {
            orderDetails = new List<OrderDetail>();
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
                orderDetails.Add(new OrderDetail(linieSplit));
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
            foreach (OrderDetail orderDetail in orderDetails)
            {
                text += orderDetail + "\n";
            }
            return text;
        }


        public string afisare()
        {
            string afis = "";
            foreach (OrderDetail orderDetail in orderDetails)
                afis += orderDetail.afisare();
            return afis;
        }

        public void adaugare(OrderDetail orderDetail)
        {
            orderDetails.Add(orderDetail);
            save();
        }

        public void stergere(int id)
        {
            this.orderDetails.RemoveAt(orderDetailId(id));
            save();
        }


        public void updateQuantity(int id, int quantityNou)
        {
            orderDetails[orderDetailId(id)].Quantity = quantityNou;
        }
        public void updatePrice(int id, int priceNou)
        {
            orderDetails[orderDetailId(id)].Price = priceNou;
        }





        public int orderDetailId(int id)
        {
            int k = 0;
            foreach (OrderDetail orderDetail in orderDetails)
                if (orderDetail.Id == id) return k;
                else k++;
            return -1;
        }


        public List<OrderDetail> OrderDetail
        {
            get => this.orderDetails;
            set => this.orderDetails = value;
        }


        public int nextId()
        {
            if (this.orderDetails.Count > 0)
                return this.orderDetails[this.orderDetails.Count - 1].Id + 1;
            else
                return 1;
        }
    }
}
