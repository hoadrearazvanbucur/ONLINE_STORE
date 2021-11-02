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
        public void saveAdaugareStergere()
        {
            //Preconditie
            ControlOrder control = new ControlOrder();
            string[] o1 = new string[] { "11", "11", "11", "11"};
            Order order1 = new Order(o1);

            //PostConditie
            control.adaugare(order1);

            ////Actiune
            control.save();
            control.load();
            outputHelper.WriteLine(control.afisare());

            //Verificare
            Assert.True(control.orderId(11) >= 0);

            //PostConditie
            control.stergere(11);

            //Actiune
            control.save();
            control.load();

            //Verificare
            Assert.True(control.orderId(11) < 0);
        }

        [Fact]
        public void updateOrderAdress()
        {
            ControlOrder control = new ControlOrder();
            string[] o1 = new string[] { "11", "11", "11", "11" };
            Order order = new Order(o1);
            control.adaugare(order);

            control.updateOrderAdress(11, "123");
            Assert.Equal("123", control.orderObjectId(11).Order_Address);

            control.stergere(11);
        }
        [Fact]
        public void updateAmmount()
        {
            ControlOrder control = new ControlOrder();
            string[] o1 = new string[] { "11", "11", "11", "11" };
            Order order = new Order(o1);
            control.adaugare(order);

            control.updateAmmount(11, 123);
            Assert.Equal(123, control.orderObjectId(11).Ammount);

            control.stergere(11);
        }
    }
}
