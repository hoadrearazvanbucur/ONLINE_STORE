using Backend.ControlClass;
using Backend.Model.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BackendTests
{
    public class ControlProductTests
    {
        private readonly ITestOutputHelper outputHelper;

        public ControlProductTests(ITestOutputHelper output)
        {
            this.outputHelper = output;
        }

        [Fact]

        public void load()
        {
            ControlProduct control = new ControlProduct();
            outputHelper.WriteLine(control.afisare());
        }

        [Fact]

        public void saveAdaugareStergere()
        {
            ControlProduct control = new ControlProduct();
            control.stergere(3);
            control.adaugare(new Phone(new string[] { "phone", "3", "3", "3", "3", "3", "3", "3", "3333", " 3333", "3333", "3333", "3333" }));
            outputHelper.WriteLine(control.afisare()+"\n\n");

            ControlProduct control1 = new ControlProduct();
            outputHelper.WriteLine(control1.afisare());
        }

        [Fact]

        public void toString()
        {
            ControlProduct control = new ControlProduct();
            outputHelper.WriteLine(control.ToString());
        }

        [Fact]

        public void modificare()
        {
            ControlProduct control = new ControlProduct();
            outputHelper.WriteLine(control.afisare() + "\n\n");

            control.updateName(3, "TEST1");
            control.updatePhoneName(3, "TEST2");

            outputHelper.WriteLine(control.afisare() + "\n\n");

        }




    }
}
