using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Backend.ControlClass;
using Backend.Class;
using Backend.Model.Products;
using Backend.Controller;

namespace Frontend
{
    public class ControlCos : Panel
    {
        private ControlOrderDetail controlOrderDetails;
        private ControlProduct controlProduct;
        private Order order;
        private Form form;

        public ControlCos(Order order,Form form)
        {
            this.controlOrderDetails = new ControlOrderDetail();
            this.controlProduct = new ControlProduct();
            this.order = order;
            this.form = form;
            layoutPanel();
            layouts();

            Label TEST = new Label();
            TEST.Location = new Point(10, 1000);
            this.Controls.Add(TEST);
        }

        public void layouts()
        {
            Label cosulMeu = new Label();
            layoutCosulMeu(cosulMeu);
            this.Controls.Add(cosulMeu);

            layoutOrders();
        }
        public void layoutOrders()
        {
            List<OrderDetail> orders = controlOrderDetails.orderListId(order.Id);

            int k1 = 40;

            foreach (OrderDetail d in orders)
            {
                ControlComanda card = new ControlComanda(controlProduct.productObjectID(d.Product_id).Name, controlProduct.productObjectID(d.Product_id).Image, controlProduct.productObjectID(d.Product_id).Price, (controlProduct.productObjectID(d.Product_id) as Phone).PhoneName, controlProduct.productObjectID(d.Product_id).Stock);
                card.Location = new Point(75, 50 + k1);
                k1 += 200;
                this.Controls.Add(card);
            }


            ControlSumar sumar = new ControlSumar(4121);
            sumar.Location = new Point(800, 90);
            this.Controls.Add(sumar);
        }


        public void layoutCosulMeu(Label cosulMeu)
        {
            cosulMeu.AutoSize = false;
            cosulMeu.Location = new Point(15, 20);
            cosulMeu.Size = new Size(300, 30);
            cosulMeu.Font = new Font("Cambria", 18, FontStyle.Regular);
            cosulMeu.BackColor = SystemColors.ControlLightLight;
            cosulMeu.Text = "Cosul meu de cumparaturi:";
        }

        public void layoutPanel()
        {
            this.Size = new Size(1175, 543);
            this.BackColor = SystemColors.ControlLightLight;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.AutoScroll = true;
        }
    }
}
