using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public delegate void confirmedEvent(double totalPrice, int senderID);
    internal class OrderProcessing
    {
        private const double TAX = 0.06;
        private const double LOCATION_CHARGE = 10.00;
        private const int CARD_MIN = 5000;
        private const int CARD_MAX = 7000;
        public static event confirmedEvent orderConfirmed;

        private Order order;
        private double unitPrice;
        private double totalPrice;

        public OrderProcessing(Order order)
        {
            this.order = order;
            unitPrice = order.getUnitPrice();
        }

        public double calcTotalPrice()
        {
            double quantityPrice = order.getUnitPrice() * order.getQuantity();
            double taxToAdd = quantityPrice * TAX;
            totalPrice = taxToAdd + quantityPrice + LOCATION_CHARGE;
            return totalPrice;
        }

        public void processOrder()
        {
            if (order != null)
            {
                Console.WriteLine("Thread {0} - Processing order {1}", Thread.CurrentThread.Name, order.getSenderID());

                if (order.getCardNo() >= CARD_MIN && order.getCardNo() <= CARD_MAX)
                {
                    Console.WriteLine("Thread {0} - VALIDATED ORDER FROM {1}", Thread.CurrentThread.Name, order.getSenderID());
                } else
                {
                    Console.WriteLine("Thread {0} - NOT VALIDATED ORDER FROM {1}", Thread.CurrentThread.Name, order.getSenderID());
                    return;
                }

                if (orderConfirmed != null)
                {
                    orderConfirmed(calcTotalPrice(), order.getSenderID());
                }
                //TODO: Send Confirmation back to ticket agent when completed
            }
        }
    }
}
