using Backend.ControlClass;
using Backend.Controller;
using Backend.Class;
using Backend.Model.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BackendTests
{
    public class ControlOrderTests
    {
        private readonly ITestOutputHelper outputHelper;

        public ControlOrderTests(ITestOutputHelper output)
        {
            this.outputHelper = output;
        }

        [Fact]
        public void load()
        {
            ControlOrder control = new ControlOrder();
            outputHelper.WriteLine(control.afisare());
        }

        [Fact]

        public void saveAdaugareStergere()
        {
            ControlOrder control = new ControlOrder();
            control.stergere(3);
            control.adaugare(new Order(new string[] {"1", "1", "1", "1","1","1"}));
            outputHelper.WriteLine(control.afisare() + "\n\n");

            ControlOrder control1 = new ControlOrder();
            outputHelper.WriteLine(control1.afisare());
        }

        [Fact]

        public void toString()
        {
            ControlOrder control = new ControlOrder();
            outputHelper.WriteLine(control.ToString());
        }

        [Fact]

        public void modificare()
        {
            ControlOrder control = new ControlOrder();
            outputHelper.WriteLine(control.afisare() + "\n\n");

            control.updateAmmount(3, 3);
            control.updateOrderAdress(3, "TEST1");

            outputHelper.WriteLine(control.afisare() + "\n\n");

        }

    }
}
