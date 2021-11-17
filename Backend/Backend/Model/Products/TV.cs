using Backend.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Model.Products
{
    public class TV : Product
    {
        private string tVName, displayType, rezolution;
        private int screenSize;


        public TV(string[] atributes) : base(atributes)
        {
            this.tVName = atributes[8];
            this.displayType = atributes[9];
            this.rezolution = atributes[10];
            this.screenSize = int.Parse(atributes[11]);
        }


        public override string ToString() => base.ToString() + "," + this.tVName + "," + this.displayType + "," + this.rezolution + "," + this.screenSize;
        public string afisare()
        {
            string afis = "";
            afis += "Nume TV: " + this.tVName + "\n";
            afis += "Tip Display: " + this.displayType + "\n";
            afis += "Rezolutie: " + this.rezolution + "\n";
            afis += "Dimensiune Ecran: " + this.screenSize + "\n\n\n";
            return afis;
        }


        public override bool Equals(object obj)
        {
            TV tv = obj as TV;
            return true;
        }


        public string TVName
        {
            get => this.tVName;
            set => this.tVName = value;
        }
        public string DisplayType
        {
            get => this.displayType;
            set => this.displayType = value;
        }
        public string Rezolution
        {
            get => this.rezolution;
            set => this.rezolution = value;
        }
        public int ScreenSize
        {
            get => this.screenSize;
            set => this.screenSize = value;
        }
    }
}
