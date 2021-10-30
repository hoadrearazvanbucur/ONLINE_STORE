using Backend.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Backend.Model.Products;
using System.Linq;

namespace Backend.ControlClass
{
    public class ControlProduct
    {
        private List<Product> products;


        public ControlProduct()
        {
            products = new List<Product>();
            load();
        }


        public void load()
        {
            this.products.Clear();
            StreamReader fisier = new StreamReader(@"D:\1_PROGRAMARE\C#\ONLINE_STORE\Backend\Backend\Controller\Resources\productFile.txt");
            string linie = "";
            while ((linie = fisier.ReadLine()) != null)
            {
                string[] linieSplit = linie.Split(',');
                if (linieSplit[0] == "phone")
                    products.Add(new Phone(linieSplit));
                //else celelalte categorii
            }
            fisier.Close();
        }
        public void save()
        {
            StreamWriter fisier = new StreamWriter(@"D:\1_PROGRAMARE\C#\ONLINE_STORE\Backend\Backend\Controller\Resources\productFile.txt");
            foreach (Product product in products)
                fisier.WriteLine((product as Phone).ToString());
            fisier.Close();
        }


        public string afisare()
        {
            string afis = "";
            foreach (Product product in products)
            {
                afis += product.afisare();
                if (product is Phone)
                {
                    Phone phone = product as Phone;
                    afis += phone.afisare();
                }
            }
            return afis;
        }
        public void adaugare(Product product)
        {
            this.products.Add(product);

        }
        public void stergere(int id)
        {
            this.products.RemoveAt(productId(id));

        }


        //Product
        public void updateName(int id, string numeNou)
        {
            products[productId(id)].Name = numeNou;
        }
        public void updateDescription(int id, string descriereNou)
        {
            products[productId(id)].Description = descriereNou;
        }
        public void updateDate(int id, string dataNou)
        {
            products[productId(id)].Date = dataNou;
        }
        public void updateImage(int id, string imagineNou)
        {
            products[productId(id)].Image = imagineNou;
        }
        public void updateStock(int id, int stocNou)
        {
            products[productId(id)].Stock = stocNou;
        }
        public void updatePrice(int id, int pretNou)
        {
            products[productId(id)].Price = pretNou;
        }

        //Phone
        public void updatePhoneName(int id, string phoneNameNou)
        {
            (products[productId(id)] as Phone).PhoneName = phoneNameNou;
        }
        public void updatePhoneColor(int id, string phoneColorNou)
        {
            (products[productId(id)] as Phone).PhoneColor = phoneColorNou;
        }
        public void updateScreenSize(int id, int screenSizeNou)
        {
            (products[productId(id)] as Phone).ScreenSize = screenSizeNou;
        }
        public void updateStorage(int id, int storageNou)
        {
            (products[productId(id)] as Phone).Storage = storageNou;
        }
        public void updateBatteryCapacity(int id, int batteryCapacityNou)
        {
            (products[productId(id)] as Phone).BatteryCapacity = batteryCapacityNou;
        }


        public int productId(int id)
        {
            int k = 0;
            foreach (Product produs in products)
                if (produs.Id == id) return k;
                else k++;
            return -1;
        }


        public Product produsId(int id)
        {
            foreach (Product produs in products)
                if (produs.Id.Equals(id) == true)
                    return produs;
            return null;
        }
        public List<Product> Products
        {
            get => this.products;
            set => this.products = value;
        }
        public List<Product> afisareCard
        {
            get => this.products;
        }


        public int nextId()
        {
            if (this.products.Count > 0)
                return this.products[this.products.Count - 1].Id + 1;
            else
                return 1;
        }
    }
}
