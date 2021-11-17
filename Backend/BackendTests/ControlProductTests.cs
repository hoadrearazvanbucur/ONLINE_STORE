using Backend.Class;
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
        public void sortFiltr()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11" };
            string[] p2 = new string[] { "phone", "22", "22", "22", "22", "22", "22", "22", "22", "22", "22", "22", "22" };
            string[] p3 = new string[] { "phone", "33", "33", "33", "33", "33", "33", "33", "33", "33", "33", "33", "33" };
            Product product1 = new Product(p1);
            Product product2 = new Product(p2);
            Product product3 = new Product(p3);
            control.adaugare(product3);
            control.adaugare(product2);
            control.adaugare(product1);

            List<Product> sort = new List<Product>();
            //sort = control.sortareNume(control.Products);
            sort = control.filtrareNume(control.Products, "33");
            foreach (Product p in sort)
                outputHelper.WriteLine(p.afisare());
        }

        [Fact]
        public void saveAdaugareStergere()
        {
            //Preconditie
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11" };
            string[] t1 = new string[] { "tv", "22", "22", "22", "22", "22", "22", "22", "22", "22", "22", "22", "22" };
            Phone product1 = new Phone(p1);
            TV tv1 = new TV(t1);

            //PostConditie
            control.adaugare(product1);
            control.adaugare(tv1);

            //Actiune
            control.save();
            control.load();

            //Verificare
            Assert.True(control.productId(11) >= 0);
            Assert.True(control.productId(22) >= 0);


            //PostConditie
            control.stergere(11);
            control.stergere(22);

            //Actiune
            control.save();
            control.load();

            //Verificare
            Assert.True(control.productId(11) < 0);
            Assert.True(control.productId(22) < 0);
        }

        [Fact]
        public void updateName()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateName(1, "TEST NUME");
            Assert.Equal("TEST NUME", control.productObjectID(1).Name);

            control.stergere(1);
        }
        [Fact]
        public void updateDescription()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateDescription(1, "TEST DESCRIERE");
            Assert.Equal("TEST DESCRIERE", control.productObjectID(1).Description);

            control.stergere(1);
        }
        [Fact]
        public void updateDate()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateDate(1, "TEST DATA");
            Assert.Equal("TEST DATA", control.productObjectID(1).Date);

            control.stergere(1);
        }
        [Fact]
        public void updateImage()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateImage(1, "TEST IMAGINE");
            Assert.Equal("TEST IMAGINE", control.productObjectID(1).Image);

            control.stergere(1);
        }
        [Fact]
        public void updateStock()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateStock(1, 123);
            Assert.Equal(123, control.productObjectID(1).Stock);

            control.stergere(1);
        }
        [Fact]
        public void updatePrice()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updatePrice(1, 1234);
            Assert.Equal(1234, control.productObjectID(1).Price);

            control.stergere(1);
        }
        [Fact]
        public void updatePhoneName()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updatePhoneName(1, "TEST Telefon Nume");
            Assert.Equal("TEST Telefon Nume", (control.productObjectID(1) as Phone).PhoneName);

            control.stergere(1);
        }
        [Fact]
        public void updatePhoneColor()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updatePhoneColor(1, "TEST Culoare");
            Assert.Equal("TEST Culoare", (control.productObjectID(1) as Phone).PhoneColor);

            control.stergere(1);
        }
        [Fact]
        public void updateScreenSize()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateScreenSizePhone(1, 12345);
            Assert.Equal(12345, (control.productObjectID(1) as Phone).ScreenSize);

            control.stergere(1);
        }
        [Fact]
        public void updateStorage()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateStorage(1, 123456);
            Assert.Equal(123456, (control.productObjectID(1) as Phone).Storage);

            control.stergere(1);
        }
        [Fact]
        public void updateBatteryCapacity()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateBatteryCapacity(1, 1234567);
            Assert.Equal(1234567, (control.productObjectID(1) as Phone).BatteryCapacity);

            control.stergere(1);
        }

        //[Fact]
        //public void update()
        //{
        //    ControlProduct control = new ControlProduct();
        //    string[] t1 = new string[] { "tv", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
        //    TV tv1 = new TV(t1);
        //    control.adaugare(tv1);

        //    control.updateTVName(1, "");
        //    Assert.Equal("", (control.productObjectID(1) as TV).);

        //    control.stergere(1);
        //}
    }
}
