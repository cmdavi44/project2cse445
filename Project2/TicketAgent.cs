using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project2
{
    internal class TicketAgent
    {
        public void ticketAgentThread()
        {
            Cruise cruise = new Cruise();
            for (Int32 i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Int32 p = cruise.getPrice();
                Console.WriteLine("TicketAgent {0} has an everyday low ticket price of: {1} each", Thread.CurrentThread.Name, p);
            }
        }

        public void ticketOnSale(Int32 p)
        {
            Console.WriteLine("Thread {0}: tickets are on sale for: {1} each", Thread.CurrentThread.Name, p);
        }
    }
}
