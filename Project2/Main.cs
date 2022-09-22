using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project2
{
    internal class Main
    {
        public class myApp
        {
            public static void Main(string[] args)
            {
                Cruise cruise1 = new Cruise();
                //Cruise cruise2 = new Cruise();
                Thread ticketPrice1 = new Thread(new ThreadStart(cruise1.priceModel));
                //Thread ticketPrice2 = new Thread(new ThreadStart(cruise2.priceModel));
                ticketPrice1.Start();
                //ticketPrice2.Start();
                TicketAgent ticketStore = new TicketAgent(); 
                Cruise.priceCut += new priceCutEvent(ticketStore.ticketOnSale);
                Thread[] ticketAgents = new Thread[5];
                for(int i = 0; i < 5; i++)
                {
                    ticketAgents[i] = new Thread(new ThreadStart(ticketStore.ticketAgentThread));
                    ticketAgents[i].Name = (i + 1).ToString();
                    ticketAgents[i].Start();
                }
            }
        }
    }
}
