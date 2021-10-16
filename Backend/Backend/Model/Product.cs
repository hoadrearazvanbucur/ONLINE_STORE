using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Class
{
    public class Product
    {
        private string categorie, name, description, date, image;
        private int id, stock;
        private double price;


        public Product(string[] atributes)
        {
            this.categorie = atributes[0];
            this.name = atributes[1];
            this.description = atributes[2];
            this.date = atributes[3];
            this.image = atributes[4];
            this.id = int.Parse(atributes[5]);
            this.stock = int.Parse(atributes[6]);
            this.price = double.Parse(atributes[7]);
        }


        public string afisare()
        {
            string afis = "";
            afis += "Categorie: " + this.categorie + "\n";
            afis += "ID: " + this.id + "\n";
            afis += "Nume: " + this.name + "\n";
            afis += "Descriere: " + this.description + "\n";
            afis += "Data creare: " + this.date + "\n";
            afis += "Imagine path: " + this.image + "\n";
            afis += "Pret: " + this.price + "\n";
            afis += "Stoc: " + this.stock + "\n\n";
            return afis;
        }
        public override string ToString() => this.categorie + "," + this.name + "," + this.description + "," + this.date + "," + this.image + "," + this.id + "," + this.stock + "," + this.price;


        public override bool Equals(object obj)
        {
            Product product = obj as Product;
            return true;
        }


        public string Categorie
        {
            get => this.categorie;
            set => this.categorie = value;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public string Description
        {
            get => this.description;
            set => this.description = value;
        }
        public string Date
        {
            get => this.date;
            set => this.date = value;
        }
        public string Image
        {
            get => this.image;
            set => this.image = value;
        }
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Stock
        {
            get => this.stock;
            set => this.stock = value;
        }
        public double Price
        {
            get => this.price;
            set => this.price = value;
        }
    }
}
