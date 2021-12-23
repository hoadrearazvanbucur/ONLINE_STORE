using Backend.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Backend.Controller
{
    public class ControlCustomer
    {
        private List<Customer> customers;

        public ControlCustomer()
        {
            customers = new List<Customer>();
            load();
        }


        public void load()
        {
            this.customers.Clear();
            string path = @"D:\1_PROGRAMARE\C#\PROIECTE\ONLINE_STORE\Backend\Backend\Controller\Resources\customerFile.txt";
            StreamReader fisier = new StreamReader(path);
            string linie = "";
            while ((linie = fisier.ReadLine()) != null){
                string[] linieSplit = linie.Split(',');
                customers.Add(new Customer(linieSplit));
            }
            fisier.Close();
        }
        public void save()
        {
            string path = @"D:\1_PROGRAMARE\C#\PROIECTE\ONLINE_STORE\Backend\Backend\Controller\Resources\customerFile.txt";
            StreamWriter fisier = new StreamWriter(path);
            foreach (Customer customer in customers)
                fisier.WriteLine(customer.ToString());
            fisier.Close();
        }


        public string afisare()
        {
            string afis = "";
            foreach (Customer customer in customers)
                afis += customer.afisare();
            return afis;
        }
        public void adaugare(Customer customer)
        {
            this.customers.Add(customer);
        }
        public void stergere(int id)
        {
            this.customers.RemoveAt(customerId(id));
        }


        public void updateEmail(int id, string emailNou)
        {
            customers[customerId(id)].Email = emailNou;
        }
        public void updatePassword(int id, string passwordNou)
        {
            customers[customerId(id)].Password = passwordNou;
        }
        public void updateFullName(int id, string fullNameNou)
        {
            customers[customerId(id)].FullName = fullNameNou;
        }


        public int customerId(int id)
        {
            int k = 0;
            foreach (Customer customer in customers)
                if (customer.Id == id) return k;
                else k++;
            return -1;
        }
        public Customer customerObjectId(int id)
        {
            foreach (Customer customer in customers)
                if (customer.Id.Equals(id) == true)
                    return customer;
            return null;
        }
        public bool accVerification(string fullName,string password)
        {
            foreach (Customer c in this.customers)
                if (c.Password.Equals(password) == true && c.FullName.Equals(fullName) == true)
                    return true;
            return false;
        }
        public Customer customerAcc(string fullName, string password)
        {
            foreach (Customer c in this.customers)
                if (c.Password.Equals(password) == true && c.FullName.Equals(fullName) == true)
                    return c;
            return null;
        }
        public List<Customer> Customers
        {
            get => this.customers;
            set => this.customers = value;
        }

        public int nextId()
        {
            if (this.customers.Count > 0)
                return this.customers[this.customers.Count - 1].Id + 1;
            else
                return 1;
        }
    }
}
