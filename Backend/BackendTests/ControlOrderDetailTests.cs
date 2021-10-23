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
    public class ControlOrderDetailTests
    {
        private readonly ITestOutputHelper outputHelper;

        public ControlOrderDetailTests(ITestOutputHelper output)
        {
            this.outputHelper = output;
        }

        [Fact]
        public void load()
        {
            ControlOrderDetail control = new ControlOrderDetail();
            outputHelper.WriteLine(control.afisare());
        }

        [Fact]

        public void saveAdaugareStergere()
        {
            ControlOrderDetail control = new ControlOrderDetail();
            control.stergere(3);
            control.adaugare(new OrderDetail(new string[] {"1", "1", "1", "1", "1", "1", "1"}));
            outputHelper.WriteLine(control.afisare() + "\n\n");

            ControlOrderDetail control1 = new ControlOrderDetail();
            outputHelper.WriteLine(control1.afisare());
        }

        [Fact]

        public void toString()
        {
            ControlOrderDetail control = new ControlOrderDetail();
            outputHelper.WriteLine(control.ToString());
        }

        [Fact]

        public void modificare()
        {
            ControlOrderDetail control = new ControlOrderDetail();
            outputHelper.WriteLine(control.afisare() + "\n\n");

            control.updatePrice(3, 1);
            control.updateQuantity(3, 1);

            outputHelper.WriteLine(control.afisare() + "\n\n");

        }

    }
}
