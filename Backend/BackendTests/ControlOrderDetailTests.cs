﻿using Backend.ControlClass;
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
        public void saveAdaugareStergere()
        {
            //Preconditie
            ControlOrderDetail control = new ControlOrderDetail();
            string[] o1 = new string[] { "1", "1", "1", "1", "1"};
            OrderDetail orderDetail1 = new OrderDetail(o1);

            //PostConditie
            control.adaugare(orderDetail1);

            //Actiune
            control.save();
            control.load();

            //Verificare
            Assert.True(control.orderDetailId(1) >= 0);


            //PostConditie
            control.stergere(1);

            //Actiune
            control.save();
            control.load();

            //Verificare
            Assert.True(control.orderDetailId(1) < 0);
        }

        [Fact]
        public void updateQuantity()
        {
            ControlOrderDetail control = new ControlOrderDetail();
            string[] p1 = new string[] {"1", "1", "1", "1", "1"};
            OrderDetail orderDetail1 = new OrderDetail(p1);
            control.adaugare(orderDetail1);

            control.updateQuantity(1, 123);
            Assert.Equal(123, control.orderDetailObjectId(1).Quantity);

            control.stergere(1);
        }

        public void update()
        {
            ControlOrderDetail control = new ControlOrderDetail();
            string[] p1 = new string[] { "1", "1", "1", "1", "1" };
            OrderDetail orderDetail1 = new OrderDetail(p1);
            control.adaugare(orderDetail1);

            control.updatePrice(1, 123);
            Assert.Equal(123, control.orderDetailObjectId(1).Price);

            control.stergere(1);
        }



    }
}
