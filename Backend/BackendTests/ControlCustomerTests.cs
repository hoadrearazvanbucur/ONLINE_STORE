using Backend.Class;
using Backend.ControlClass;
using Backend.Controller;
using Backend.Model.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BackendTests
{
    public class ControlCustomerTests
    {
        private readonly ITestOutputHelper outputHelper;
        public ControlCustomerTests(ITestOutputHelper output)
        {
            this.outputHelper = output;
        }


        [Fact]
        public void saveAdaugareStergere()
        {
            //Preconditie
            ControlCustomer control = new ControlCustomer();
            string[] c1 = new string[] { "11", "11", "11", "11"};
            Customer customer1 = new Customer(c1);

            //PostConditie
            control.adaugare(customer1);

            ////Actiune
            control.save();
            control.load();
            outputHelper.WriteLine(control.afisare());

            //Verificare
            Assert.True(control.customerId(11) >= 0);


            //PostConditie
            control.stergere(11);

            //Actiune
            control.save();
            control.load();

            //Verificare
            Assert.True(control.customerId(11) < 0);
        }

        [Fact]
        public void updateFullName()
        {
            ControlCustomer control = new ControlCustomer();
            string[] c1 = new string[] { "11", "11", "11", "11"};
            Customer customer = new Customer(c1);
            control.adaugare(customer);

            control.updateFullName(11, "123");
            Assert.Equal("123", control.customerObjectId(11).FullName);

            control.stergere(11);
        }
        [Fact]
        public void updateEmail()
        {
            ControlCustomer control = new ControlCustomer();
            string[] c1 = new string[] { "11", "11", "11", "11" };
            Customer customer = new Customer(c1);
            control.adaugare(customer);

            control.updateEmail(11, "123");
            Assert.Equal("123", control.customerObjectId(11).Email);

            control.stergere(11);
        }
        [Fact]
        public void updatePassword()
        {
            ControlCustomer control = new ControlCustomer();
            string[] c1 = new string[] { "11", "11", "11", "11" };
            Customer customer = new Customer(c1);
            control.adaugare(customer);

            control.updatePassword(11, "123");
            Assert.Equal("123", control.customerObjectId(11).Password);

            control.stergere(11);
        }

    }
}
