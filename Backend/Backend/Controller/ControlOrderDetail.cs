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
            this.orderDetails.Clear();
            StreamReader fisier = new StreamReader(@"D:\1_PROGRAMARE\C#\ONLINE_STORE\Backend\Backend\Controller\Resources\orderDetailFile.txt");
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
            StreamWriter fisier = new StreamWriter(@"D:\1_PROGRAMARE\C#\ONLINE_STORE\Backend\Backend\Controller\Resources\orderDetailFile.txt");
            foreach (OrderDetail orderDetail in orderDetails)
                fisier.WriteLine(orderDetail.ToString());
            fisier.Close();
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
        }
        public void stergere(int id)
        {
            this.orderDetails.RemoveAt(orderDetailId(id));
        }


        public void updateQuantity(int id, int quantityNou)
        {
            orderDetails[orderDetailId(id)].Quantity = quantityNou;
        }
        public void updatePrice(int id, double priceNou)
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
        public OrderDetail orderDetailObjectId(int id)
        {
            foreach (OrderDetail orderDetail in orderDetails)
                if (orderDetail.Id.Equals(id) == true)
                    return orderDetail;
            return null;
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
