using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace Project2
{
    internal class TicketAgent
    {
        
        public void ticketAgentThread()
        {




            /*Cruise cruise = new Cruise();
            for (Int32 i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Int32 p = cruise.getPrice();
                Console.WriteLine("TicketAgent {0} has a ticket price of: {1} each", Thread.CurrentThread.Name, p);
            }*/
        }


        public int calcQuantity(double price, double oldPrice)
        {
            int quantity = 0;
            double priceDiff = oldPrice - price;

            if (priceDiff >= 1 && priceDiff <= 10)
            {
                quantity = 1;
            } else if (priceDiff >= 11 && priceDiff <= 30)
            {
                quantity = 5;
            } else if (priceDiff >= 31 && priceDiff <= 50)
            {
                quantity = 10;
            } else if (priceDiff >= 51 && priceDiff <= 70)
            {
                quantity = 20;
            } else if (priceDiff >= 71)
            {
                quantity = 40;
            } 

            return quantity;
        }
        // Make the order object here
        // Based on factors. The number of tickets to buy is based on the difference between the
        // previous price and the current price
        public void ticketOnSale(double price, double oldPrice)
        {
            Random rnd = new Random();
            // Credit card number randomly generated, has a chance of being invalid
            int creditCard = rnd.Next(4900, 7100);
            Console.WriteLine("Ticket Agent {0} has tickets on sale as low as ${1} each", Thread.CurrentThread.Name, price);

            Order order = new Order(Thread.CurrentThread.Name, creditCard, 5, calcQuantity(price, oldPrice), ;
        }

        public void orderConfirmation(double totalPrice, int senderID)
        {
            Console.WriteLine("Thread {0} - PROCESSED ORDER {1}\nTOTAL PRICE: {2}", Thread.CurrentThread.Name, senderID, totalPrice);
        }
    }
}
