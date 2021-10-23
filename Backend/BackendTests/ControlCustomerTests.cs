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
        public void load()
        {
            ControlCustomer control = new ControlCustomer();
            outputHelper.WriteLine(control.afisare());
        }

        [Fact]

        public void saveAdaugareStergere()
        {
            ControlCustomer control = new ControlCustomer();
            control.adaugare(new Customer(new string[] { "1", "1", "1", "1", "1", "1", "1" }));

        }

        [Fact]

        public void toString()
        {
            ControlCustomer control = new ControlCustomer();
            outputHelper.WriteLine(control.ToString());
        }

        [Fact]

        public void modificare()
        {
            ControlCustomer control = new ControlCustomer();
            outputHelper.WriteLine(control.afisare() + "\n\n");

            control.updateEmail(3, "TEST1");
            control.updateFullName(3, "TEST2");
            control.updatePassword(3, "TEST3");

            outputHelper.WriteLine(control.afisare() + "\n\n");

        }

    }
}
