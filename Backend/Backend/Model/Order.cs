using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Class
{
    public class Order
    {
        private int id, customer_id, ammount;
        private string order_address;


        public Order(string[] atributes)
        {
            this.id = int.Parse(atributes[0]);
            this.customer_id = int.Parse(atributes[1]);
            this.ammount = int.Parse(atributes[2]);
            this.order_address = atributes[3];
        }


        public string ToString() => this.id + "," + this.customer_id + "," + this.ammount + "," + this.order_address;
        public string afisare()
        {
            string afis = "";
            afis += "ID: " + this.id + "\n";
            afis += "ID Cumparator: " + this.customer_id + "\n";
            afis += "Cantitate: " + this.ammount + "\n";
            afis += "Adresa Cumparator: " + this.order_address + "\n\n";          
            return afis;
        }


        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return true;
        }


        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Custormer_id
        {
            get => this.customer_id;
            set => this.customer_id = value;
        }
        public int Ammount
        {
            get => this.ammount;
            set => this.ammount = value;
        }
        public string Order_Address
        {
            get => this.order_address;
            set => this.order_address = value;
        }
    }
}
