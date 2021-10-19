using Backend.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Model.Products
{
    public class Phone : Product
    {
        private string phoneName, phoneColor;
        private int screenSize, storage, batteryCapacity;


        public Phone(string[] atributes) : base(atributes)
        {
            this.phoneName = atributes[8];
            this.phoneColor = atributes[9];
            this.screenSize = int.Parse(atributes[10]);
            this.storage = int.Parse(atributes[11]);
            this.batteryCapacity = int.Parse(atributes[12]);
        }


        public override string ToString() => base.ToString() + "," + this.phoneName + "," + this.phoneColor + "," + this.screenSize + "," + this.storage + "," + this.batteryCapacity;
        public string afisare()
        {
            string afis = "";
            afis += "Nume Telefon: " + this.phoneName + "\n";
            afis += "Culoare: " + this.phoneColor + "\n";
            afis += "Dimensiune Ecran: " + this.screenSize + "\n";
            afis += "Stocare: " + this.storage + "\n";
            afis += "Capacitate Baterie: " + this.batteryCapacity + "\n\n\n";
            return afis;
        }


        public override bool Equals(object obj)
        {
            Phone phone = obj as Phone;
            return true;
        }


        public string PhoneName
        {
            get => this.phoneName;
            set => this.phoneName = value;
        }
        public string PhoneColor
        {
            get => this.phoneColor;
            set => this.phoneColor = value;
        }
        public int ScreenSize
        {
            get => this.screenSize;
            set => this.screenSize = value;
        }
        public int Storage
        {
            get => this.storage;
            set => this.storage = value;
        }
        public int BatteryCapacity
        {
            get => this.batteryCapacity;
            set => this.batteryCapacity = value;
        }
    }
}
