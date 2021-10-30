using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Class
{
    public class OrderDetail
    {
        private int id, order_id, product_id, quantity;
        private double price;


        public OrderDetail(string[] atributes)
        {
            this.id = int.Parse(atributes[0]);
            this.order_id = int.Parse(atributes[1]);
            this.product_id = int.Parse(atributes[2]);
            this.quantity = int.Parse(atributes[3]);
            this.price = double.Parse(atributes[4]);
        }


        public string ToString() => this.id + "," + this.order_id + "," + this.product_id + "," + this.quantity + "," + this.price;
        public string afisare()
        {
            string afis = "";
            afis += "ID: " + this.id + "\n";
            afis += "Comanda ID: " + this.order_id + "\n";
            afis += "Produs ID: " + this.product_id + "\n";
            afis += "Cantitate: " + this.quantity + "\n";
            afis += "Pret: " + this.price + "\n\n";      
            return afis;
        }


        public bool Equals(object obj)
        {
            OrderDetail orderDetail = obj as OrderDetail;
            return true;
        }


        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Order_id
        {
            get => this.order_id;
            set => this.order_id = value;
        }
        public int Product_id
        {
            get => this.product_id;
            set => this.product_id = value;
        }
        public int Quantity
        {
            get => this.quantity;
            set => this.quantity = value;
        }
        public double Price
        {
            get => this.price;
            set => this.price = value;
        }
    }
}
