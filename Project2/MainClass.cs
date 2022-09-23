using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


/* WHAT IS DONE?
 *   - OrderProcessing
 *   - OrderClass
*/

/* WHAT IS NOT DONE?
 *  - Main
 *  - MultiCellBuffer
 *  - Order object creation inside of ticket agent (WORKING ON IT)
 *  - Cruise
 *      - Creation of order processing thread
 *      - PricingModel
 *      - Consuming MultiCellBuffer
 */

/* WHAT NEEDS TO BE TESTED? 
 *  - See if event handler for ticketOnSale() is working 
 *  - See if event handler for orderConfirmation() is working 
*/

namespace Project2
{
    internal class MainClass
    {
        private const int K = 2; //# of cruise
        private const int N = 5; //# of ticketAgents
        //Create the threads needed
        private static Thread[] cruiseThreads = new Thread[K];
        private static Thread[] ticketAgents = new Thread[N];
        private static Cruise[] cruiseSupplier = new Cruise[K];
        //Create the buffer
        //public static MultiCellBuffer buffer = new MultiCellBuffer();

        public static void Main(string[] args)
        {
            //Create the two cruise threads
            for (int i = 0; i < K; i++)
            {
                Cruise cruise = new Cruise();
                cruiseSupplier[i] = cruise;
                cruiseThreads[i] = new Thread(cruise.priceModel);
                cruiseThreads[i].Name    = "Cruise_" + i;
                cruiseThreads[i].Start();
                //If the thread is alive then the while statement never gets used
                while(!cruiseThreads[i].IsAlive);
            }
            
            //Create the ticketAgents
            for (int i = 0; i < N; i++)
            {
                TicketAgent ticketAgent = new TicketAgent();
                //Might have to add a way for the ticketAgents to connect to the Price Cut Event
                ticketAgents[i] = new Thread(ticketAgent.ticketAgentThread);
                ticketAgents[i].Name = "TicketAgent_" + i;
                ticketAgents[i].Start();
                while(!ticketAgents[i].IsAlive);
            }

            //Wait until the cruiseThread have price cut 20 times then continue
            for (int i = 0; i < K; ++i)
            {
                while(cruiseThreads[i].IsAlive) ;
            }

            //Tell the ticketAgents that the cruises pricecut events are done
            //for (int i = 0; i < N; ++i)
            //{
            //    TicketAgent.cruiseActive = false;
            //}

            // Wait for the ticketAgents to close
            for (int i = 0; i < N; ++i)
            {
                while(ticketAgents[i].IsAlive) ;
            }

            Console.WriteLine("\n\nPROGRAM COMPLETED");
        }
    }
    
}
