using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Class
{
    public class Customer
    {
        private string email, password, full_name;
        private int id;


        public Customer(string[] atributes)
        {
            this.email = atributes[0];
            this.password = atributes[1];
            this.full_name = atributes[2];
            this.id = int.Parse(atributes[3]);
        }


        public string ToString() => this.email + "," + this.password + "," + this.full_name + "," + this.id;
        public string afisare()
        {
            string afis = "";
            afis += "Email: " + this.email + "\n";
            afis += "Parola: " + this.password + "\n";
            afis += "Nume: " + this.full_name + "\n";
            afis += "ID: " + this.id + "\n\n";
            return afis;
        }


        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            return true;
        }


        public string Email
        {
            get => this.email;
            set => this.email = value;
        }
        public string Password
        {
            get => this.password;
            set => this.password = value;
        }
        public string FullName
        {
            get => this.full_name;
            set => this.full_name = value;
        }
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
    }
}
